class PermissionModule {
    #apiService;
    #auth;
    #dataCache;

    constructor(apiService, auth, dataCache) {
        this.#apiService = apiService;
        this.#auth = auth;
        this.#dataCache = dataCache;
    }

    initPermissionsPage() {

        $('#permissionsGrid').kendoGrid({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getPermissions()
                            .done(result => {
                                options.success(result);
                                this.#dataCache.permissions = result;
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
                            name: { type: 'string' },
                            description: { type: 'string' },
                            category: { type: 'string' }
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
                { field: 'name', title: 'Название', width: '20%' },
                { field: 'description', title: 'Описание', width: '25%' },
                { field: 'category', title: 'Категория', width: '15%' },
                {
                    field: 'rolePermissions',
                    title: 'Роли с этим правом',
                    width: '20%',
                    template: (dataItem) => {
                        const roles = this.#dataCache.roles?.filter(role =>
                            role.permissions?.some(p => p.id === dataItem.id)
                        ) || [];
                        return roles.map(r => r.name).join(', ');
                    }
                },
                {
                    command: [
                        {
                            name: 'editPermission',
                            text: 'Редактировать',
                            iconClass: 'k-icon k-i-pencil',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#permissionsGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.showPermissionDialog(dataItem);
                            }
                        },
                        {
                            name: 'delete',
                            text: 'Удалить',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#permissionsGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.deletePermission(dataItem.id);
                            }
                        }
                    ],
                    width: '20%',
                    attributes: { style: 'text-align: center;' }
                }
            ],
            dataBound: () => {
                this.updateGridColumnVisibility();
            }
        });

        $('#addPermissionBtn').on('click', () => this.showPermissionDialog());
        this.initPermissionFilters();
    }

    initPermissionFilters() {
        $('#permissionSearch').on('input', function () {
            const searchTerm = $(this).val().toLowerCase();
            const grid = $('#permissionsGrid').data('kendoGrid');
            if (grid) {
                grid.dataSource.filter({
                    logic: 'or',
                    filters: [
                        { field: 'name', operator: 'contains', value: searchTerm },
                        { field: 'description', operator: 'contains', value: searchTerm },
                        { field: 'category', operator: 'contains', value: searchTerm }
                    ]
                });
            }
        });

        $('#categoryFilter').kendoDropDownList({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getPermissions()
                            .done(permissions => {
                                const categories = ['Все категории', ...new Set(permissions.map(p => p.category))];
                                options.success(categories);
                            })
                            .fail(xhr => {
                                options.error(xhr);
                                App.handleAjaxError(xhr);
                            });
                    }
                }
            },
            change: (e) => {
                const selectedCategory = e.sender.value();
                const grid = $('#permissionsGrid').data('kendoGrid');
                if (grid) {
                    if (selectedCategory !== 'Все категории') {
                        grid.dataSource.filter({
                            field: 'category',
                            operator: 'eq',
                            value: selectedCategory
                        });
                    } else {
                        grid.dataSource.filter({});
                    }
                }
            }
        });
    }

    updateGridColumnVisibility() {
        const grid = $('#permissionsGrid').data('kendoGrid');
        if (grid) {
            if (this.#auth.isAdmin()) {
                grid.showColumn('command');
            } else {
                grid.hideColumn('command');
            }
        }
    }

    showPermissionDialog(permission = null) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для выполнения этой операции.', 'warning');
            return;
        }

        const isEdit = !!permission;
        const title = isEdit ? 'Редактирование права' : 'Добавление права';

        if (!$('#permissionDialog').length) {
            $('body').append('<div id="permissionDialog"></div>');
        }

        const dialog = $('#permissionDialog').kendoDialog({
            width: '500px',
            title: title,
            closable: true,
            modal: true,
            content: $('#permission-dialog-template').html(),
            actions: [
                { text: 'Отмена' },
                { text: 'Сохранить', primary: true, action: () => this.savePermission(isEdit, permission?.id) }
            ],
            visible: false,
            open: () => {
                if (isEdit) {
                    $('#permissionName').val(permission.name);
                    $('#permissionDescription').val(permission.description);
                    $('#permissionCategory').val(permission.category);
                }

                this.#apiService.getPermissions()
                    .done(permissions => {
                        const categories = [...new Set(permissions.map(p => p.category))];
                        $('#permissionCategory').kendoComboBox({
                            dataSource: categories,
                            filter: 'contains',
                            placeholder: 'Выберите или введите категорию...',
                            clearButton: false,
                            value: isEdit ? permission.category : ''
                        });
                    })
                    .fail(App.handleAjaxError);
            }
        }).data('kendoDialog');

        dialog.open();
    }

    savePermission(isEdit, permissionId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для сохранения права.', 'warning');
            return false;
        }

        const name = $('#permissionName').val();
        const description = $('#permissionDescription').val();
        const category = $('#permissionCategory').val();

        if (!name || !category) {
            App.showNotification('Название и категория обязательны для заполнения', 'error');
            return false;
        }

        const permissionData = {
            name: name,
            description: description,
            category: category
        };

        if (isEdit) {
            this.#apiService.updatePermission(permissionId, permissionData)
                .done(() => {
                    $('#permissionsGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Право успешно обновлено', 'success');
                })
                .fail(App.handleAjaxError);
        } else {
            this.#apiService.createPermission(permissionData)
                .done(() => {
                    $('#permissionsGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Право успешно создано', 'success');
                })
                .fail(App.handleAjaxError);
        }

        return true;
    }

    deletePermission(permissionId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для удаления права.', 'warning');
            return;
        }

        if (confirm('Вы уверены, что хотите удалить это право?')) {
            this.#apiService.deletePermission(permissionId)
                .done(() => {
                    $('#permissionsGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Право успешно удалено', 'success');
                })
                .fail(App.handleAjaxError);
        }
    }
}