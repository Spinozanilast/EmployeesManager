class EmployeeModule {
    EMPLOYEE_DETAILS_PAGE = 'employee-details';

    #apiService;
    #auth;
    #dataCache;

    #navigationCallback;


    constructor(apiService, auth, dataCache, navivationCallback) {
        this.#navigationCallback = navivationCallback;
        this.#apiService = apiService;
        this.#auth = auth;
        this.#dataCache = dataCache;
    }

    initEmployeesPage() {
        $('#employeesGrid').kendoGrid({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getEmployees()
                            .done(result => {
                                options.success(result);
                                this.#dataCache.employees = result;
                                this.updateGridColumnVisibility();
                            })
                            .fail(xhr => {
                                options.error(xhr);
                                App.handleAjaxError(xhr);
                            });
                    }
                },
                schema: {
                    model: {
                        id: 'id',
                        fields: {
                            id: { type: 'string' },
                            fullName: { type: 'string' },
                            firstName: { type: 'string' },
                            lastName: { type: 'string' },
                            middleName: { type: 'string' },
                            roles: { type: 'object' }
                        }
                    }
                },
                pageSize: 10
            },
            height: 550,
            sortable: true,
            filterable: true,
            pageable: {
                refresh: true,
                pageSizes: [5, 10, 25, 50, 'Все']
            },
            columns: [
                { field: 'fullName', title: 'ФИО', width: '30%' },
                {
                    field: 'roles',
                    title: 'Роли',
                    width: '40%',
                    template: (dataItem) => {
                        if (!dataItem.roles || dataItem.roles.length === 0) {
                            return '<span class="text-muted">Нет ролей</span>';
                        }
                        return dataItem.roles.map(role =>
                            `<span class="role-tag">${kendo.htmlEncode(role.name)}</span>`
                        ).join(' ');
                    }
                },
                {
                    command: [
                        {
                            name: 'view',
                            text: 'Просмотр',
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#employeesGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.viewEmployeeDetails(dataItem.id);
                            }
                        },
                        {
                            name: 'editEmployee',
                            text: 'Редактировать',
                            iconClass: 'k-icon k-i-pencil',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#employeesGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.showEmployeeDialog(dataItem);
                            }
                        },
                        {
                            name: 'delete',
                            text: 'Удалить',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#employeesGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.deleteEmployee(dataItem.id);
                            }
                        }
                    ],
                    width: '30%',
                    attributes: { style: 'text-align: center;' }
                }
            ],
            dataBound: () => {
                this.updateGridColumnVisibility();
            }
        });

        $('#addEmployeeBtn').on('click', () => this.showEmployeeDialog());
    }

    initEmployeeFilters() {
        $('#employeeSearch').on('input', function () {
            const searchTerm = $(this).val().toLowerCase();
            const grid = $('#employeesGrid').data('kendoGrid');
            if (grid) {
                grid.dataSource.filter({
                    logic: 'or',
                    filters: [
                        { field: 'fullName', operator: 'contains', value: searchTerm }
                    ]
                });
            }
        });

        $('#roleFilter').kendoDropDownList({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getRoles()
                            .done(result => options.success(result))
                            .fail(xhr => {
                                options.error(xhr);
                                App.handleAjaxError(xhr);
                            });
                    }
                },
                schema: {
                    model: {
                        id: 'id',
                        fields: {
                            id: { type: 'string' },
                            name: { type: 'string' }
                        }
                    }
                }
            },
            dataTextField: 'name',
            dataValueField: 'id',
            optionLabel: 'Выберите роль...',
            change: (e) => {
                const roleId = e.sender.value();
                const grid = $('#employeesGrid').data('kendoGrid');
                if (grid) {
                    if (roleId) {
                        grid.dataSource.filter({
                            logic: 'and',
                            filters: [
                                {
                                    field: 'roles',
                                    operator: (roles, filterValue) => {
                                        if (!roles || !roles.length) return false;
                                        return roles.some(role => role.id === filterValue);
                                    },
                                    value: roleId
                                }
                            ]
                        });
                    } else {
                        grid.dataSource.filter({});
                    }
                }
            }
        });
    }

    updateGridColumnVisibility() {
        const grid = $('#employeesGrid').data('kendoGrid');
        if (grid) {
            if (this.#auth.isAdmin()) {
                grid.showColumn('command');
            } else {
                grid.hideColumn('command');
            }
        }
    }

    viewEmployeeDetails(employeeId) {
        this.#navigationCallback(this.EMPLOYEE_DETAILS_PAGE);
        this.#apiService.getEmployeeById(employeeId)
            .done(employee => {
                $('#employeeFullName').text(employee.fullName);
                $('#employeeFirstName').text(employee.firstName);
                $('#employeeLastName').text(employee.lastName);
                $('#employeeMiddleName').text(employee.middleName || '-');

                const rolesHtml = employee.roles && employee.roles.length
                    ? employee.roles.map(role => `<div class="role-tag">${kendo.htmlEncode(role.name)}</div>`).join('')
                    : '<div class="text-muted">Нет назначенных ролей</div>';
                $('#employeeRolesList').html(rolesHtml);

                this.#apiService.getEmployeePermissions(employeeId)
                    .done(permissions => {
                        const permissionsByCategory = {};
                        permissions.forEach(permission => {
                            if (!permissionsByCategory[permission.category]) {
                                permissionsByCategory[permission.category] = [];
                            }
                            permissionsByCategory[permission.category].push(permission);
                        });

                        let permissionsHtml = '';
                        if (Object.keys(permissionsByCategory).length === 0) {
                            permissionsHtml = '<div class="text-muted">Нет прав</div>';
                        } else {
                            for (const category in permissionsByCategory) {
                                permissionsHtml += `<div class="permission-category">${kendo.htmlEncode(category)}</div>`;
                                permissionsHtml += '<div class="permission-list">';
                                permissionsByCategory[category].forEach(permission => {
                                    permissionsHtml += `<div class="permission-tag" title="${kendo.htmlEncode(permission.description || '')}">${kendo.htmlEncode(permission.name)}</div>`;
                                });
                                permissionsHtml += '</div>';
                            }
                        }
                        $('#employeePermissionsList').html(permissionsHtml);
                    })
                    .fail(App.handleAjaxError);
            })
            .fail(App.handleAjaxError);
    }

    showEmployeeDialog(employee = null) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для выполнения этой операции.', 'warning');
            return;
        }
        const isEdit = !!employee;
        const title = isEdit ? 'Редактирование сотрудника' : 'Добавление сотрудника';

        const dialog = $('#employeeDialog').kendoDialog({
            width: '500px',
            title: title,
            closable: true,
            modal: true,
            content: $('#employee-dialog-template').html(),
            actions: [
                { text: 'Отмена' },
                { text: 'Сохранить', primary: true, action: () => this.saveEmployee(isEdit, employee?.id) }
            ],
            open: () => {
                if (isEdit) {
                    $('#firstName').val(employee.firstName);
                    $('#lastName').val(employee.lastName);
                    $('#middleName').val(employee.middleName);
                }

                this.#apiService.getRoles()
                    .done(roles => {
                        $('#employeeRolesListBox').kendoListBox({
                            dataSource: roles,
                            dataTextField: 'name',
                            dataValueField: 'id',
                            selectable: 'multiple',
                            draggable: false,
                            dropSources: [],
                            toolbar: {
                                tools: [
                                    'moveUp',
                                    'moveDown',
                                    'transferTo',
                                    'transferFrom',
                                    'transferAllTo',
                                    'transferAllFrom'
                                ]
                            }
                        });

                        if (isEdit) {
                            this.#apiService.getEmployeeRoles(employee.id)
                                .done(employeeRoles => {
                                    const listBox = $('#employeeRolesListBox').data('kendoListBox');
                                    const items = listBox.items();
                                    items.each(function (index, item) {
                                        const roleId = listBox.dataItem(item).id;
                                        if (employeeRoles.some(role => role.id === roleId)) {
                                            listBox.select(item);
                                        }
                                    });
                                })
                                .fail(App.handleAjaxError);
                        }
                    })
                    .fail(App.handleAjaxError);
            }
        }).data('kendoDialog');

        dialog.open();
    }

    saveEmployee(isEdit, employeeId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для сохранения сотрудника.', 'warning');
            return false;
        }

        const firstName = $('#firstName').val();
        const lastName = $('#lastName').val();
        const middleName = $('#middleName').val();

        if (!firstName || !lastName) {
            App.showNotification('Имя и фамилия обязательны для заполнения', 'error');
            return false;
        }

        const employeeData = {
            firstName: firstName,
            lastName: lastName,
            middleName: middleName
        };

        const listBox = $('#employeeRolesListBox').data('kendoListBox');
        const selectedRoleIds = [];

        if (listBox) {
            const selectedItems = listBox.select();
            selectedItems.each(function (index, item) {
                const roleId = listBox.dataItem(item).id;
                selectedRoleIds.push(roleId);
            });
        }

        if (isEdit) {
            this.#apiService.updateEmployee(employeeId, employeeData)
                .done(() => {
                    this.#apiService.assignRolesToEmployee(employeeId, selectedRoleIds)
                        .done(() => {
                            $('#employeesGrid').data('kendoGrid').dataSource.read();
                            App.showNotification('Сотрудник успешно обновлен', 'success');
                        })
                        .fail(App.handleAjaxError);
                })
                .fail(App.handleAjaxError);
        } else {
            this.#apiService.createEmployee(employeeData)
                .done((result) => {
                    if (selectedRoleIds.length > 0) {
                        this.#apiService.assignRolesToEmployee(result.id, selectedRoleIds)
                            .done(() => {
                                $('#employeesGrid').data('kendoGrid').dataSource.read();
                                App.showNotification('Сотрудник успешно создан', 'success');
                            })
                            .fail(App.handleAjaxError);
                    } else {
                        $('#employeesGrid').data('kendoGrid').dataSource.read();
                        App.showNotification('Сотрудник успешно создан', 'success');
                    }
                })
                .fail(App.handleAjaxError);
        }

        return true;
    }
}