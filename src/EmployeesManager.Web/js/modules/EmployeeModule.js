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
        this.initEmployeeFilters();

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

        $('#permissionFilter').kendoMultiSelect({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getPermissions()
                            .done(result => {
                                const permissions = result.map(p => ({
                                    id: p.id,
                                    name: `${p.category} - ${p.name}`
                                }));
                                options.success(permissions);
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
                            name: { type: 'string' }
                        }
                    }
                }
            },
            dataTextField: 'name',
            dataValueField: 'id',
            placeholder: 'Выберите права...',
            change: (e) => {
                const selectedPermissions = e.sender.value();
                const grid = $('#employeesGrid').data('kendoGrid');
                if (grid) {
                    if (selectedPermissions && selectedPermissions.length > 0) {
                        grid.dataSource.filter({
                            logic: 'and',
                            filters: [
                                {
                                    field: 'roles',
                                    operator: (roles, filterValue) => {
                                        if (!roles || !roles.length) return false;
                                        return roles.some(role =>
                                            role.permissions && filterValue.every(permId =>
                                                role.permissions.some(p => p.id === permId)
                                            )
                                        );
                                    },
                                    value: selectedPermissions
                                }
                            ]
                        });
                    } else {
                        grid.dataSource.filter({});
                    }
                }
            }
        });

        $('#roleFilter').kendoMultiSelect({
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
            placeholder: 'Выберите роли...',
            change: (e) => {
                const selectedRoles = e.sender.value();
                const grid = $('#employeesGrid').data('kendoGrid');
                if (grid) {
                    if (selectedRoles && selectedRoles.length > 0) {
                        grid.dataSource.filter({
                            logic: 'and',
                            filters: [
                                {
                                    field: 'roles',
                                    operator: (roles, filterValue) => {
                                        if (!roles || !roles.length) return false;
                                        return roles.some(role => filterValue.includes(role.id));
                                    },
                                    value: selectedRoles
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

                $('#editEmployeeBtn').off('click').on('click', () => this.showEmployeeDialog(employee));
                $('#assignRolesBtn').off('click').on('click', () => this.showAssignRolesDialog(employee));

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
                            permissionsHtml += '<div class="permissions-container horizontal-scroll">';
                            for (const category in permissionsByCategory) {
                                permissionsHtml += `<div class="permission-category">${kendo.htmlEncode(category)}`;
                                permissionsHtml += '<div class="permission-list">';
                                permissionsByCategory[category].forEach(permission => {
                                    permissionsHtml += `<div class="permission-tag" title="${kendo.htmlEncode(permission.description || '')}">${kendo.htmlEncode(permission.name)}</div>`;
                                });
                                permissionsHtml += '</div></div>';
                            }
                        }
                        $('#employeePermissionsList').html(permissionsHtml + '</div>');
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
                    .done((roles) => {
                        let assignedRoleIds = [];
                        if (isEdit) {
                            this.#apiService.getEmployeeRoles(employee.id)
                                .done(employeeRoles => {
                                    assignedRoleIds = employeeRoles.map(r => r.id);
                                    $('#employeeRolesMultiSelect').kendoMultiSelect({
                                        dataSource: roles,
                                        dataTextField: 'name',
                                        dataValueField: 'id',
                                        value: assignedRoleIds,
                                        placeholder: 'Выберите роли...'
                                    });
                                })
                                .fail(App.handleAjaxError);
                        } else {
                            $('#employeeRolesMultiSelect').kendoMultiSelect({
                                dataSource: roles,
                                dataTextField: 'name',
                                dataValueField: 'id',
                                placeholder: 'Выберите роли...'
                            });
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
        const selectedRoleIds = $('#employeeRolesMultiSelect').data('kendoMultiSelect') ? $('#employeeRolesMultiSelect').data('kendoMultiSelect').value() : [];
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
                .done((employeeId) => {
                    if (selectedRoleIds.length > 0) {
                        this.#apiService.assignRolesToEmployee(employeeId, selectedRoleIds)
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

    showAssignRolesDialog(employee) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для выполнения этой операции.', 'warning');
            return;
        }
        const dialog = $('#assignRolesDialog').kendoDialog({
            width: '500px',
            title: 'Назначение ролей',
            closable: true,
            modal: true,
            content: $('#assign-roles-dialog-template').html(),
            actions: [
                { text: 'Отмена' },
                { text: 'Сохранить', primary: true, action: () => this.saveAssignedRoles(employee.id) }
            ],
            open: () => {
                this.#apiService.getRoles()
                    .done(roles => {
                        this.#apiService.getEmployeeRoles(employee.id)
                            .done(employeeRoles => {
                                const assignedRoleIds = employeeRoles.map(r => r.id);
                                $('#assignRolesMultiSelect').kendoMultiSelect({
                                    dataSource: roles,
                                    dataTextField: 'name',
                                    dataValueField: 'id',
                                    value: assignedRoleIds,
                                    placeholder: 'Выберите роли...'
                                });
                            })
                            .fail(App.handleAjaxError);
                    })
                    .fail(App.handleAjaxError);
            }
        }).data('kendoDialog');
        dialog.open();
    }

    saveAssignedRoles(employeeId) {
        const selectedRoleIds = $('#assignRolesMultiSelect').data('kendoMultiSelect') ? $('#assignRolesMultiSelect').data('kendoMultiSelect').value() : [];
        this.#apiService.assignRolesToEmployee(employeeId, selectedRoleIds)
            .done(() => {
                $('#employeeRolesList').html('');
                $('#employeesGrid').data('kendoGrid').dataSource.read();
                App.showNotification('Роли успешно обновлены', 'success');
            })
            .fail(App.handleAjaxError);
        return true;
    }

    deleteEmployee(employeeId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для удаления права сотрудника.', 'warning');
            return;
        }

        if (confirm('Вы уверены, что хотите удалить этого сотрудника?')) {
            this.#apiService.deleteEmployee(employeeId)
                .done(() => {
                    $('#employeesGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Пользователь успешно удален', 'success');
                })
                .fail(App.handleAjaxError);
        }
    }
}