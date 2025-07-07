class RoleModule {
    #apiService;
    #auth;
    #dataCache;


    constructor(apiService, auth, dataCache) {
        this.#apiService = apiService;
        this.#auth = auth;
        this.#dataCache = dataCache;
    }

    initRolesPage() {

        $('#rolesGrid').kendoGrid({
            dataSource: {
                transport: {
                    read: (options) => {
                        this.#apiService.getRoles()
                            .done(result => {
                                options.success(result);
                                this.#dataCache.roles = result;
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
                            description: { type: 'string' }
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
            editable: "popup",
            columns: [
                { field: 'name', title: 'Название', width: '20%' },
                { field: 'description', title: 'Описание', width: '20%' },
                { field: 'permissions', title: 'Права', width: '30%' },
                {
                    command: [
                        {
                            name: 'editRole',
                            iconClass: 'k-icon k-i-pencil',
                            text: 'Редактировать',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#rolesGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.showRoleDialog(dataItem);
                            }
                        },
                        {
                            name: 'delete',
                            text: 'Удалить',
                            visible: () => this.#auth.isAdmin(),
                            click: (e) => {
                                e.preventDefault();
                                const dataItem = $('#rolesGrid').data('kendoGrid').dataItem($(e.currentTarget).closest('tr'));
                                this.deleteRole(dataItem.id);
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

        $('#addRoleBtn').on('click', () => this.showRoleDialog());
    }

    updateGridColumnVisibility() {
        const grid = $('#rolesGrid').data('kendoGrid');
        if (grid) {
            if (this.#auth.isAdmin()) {
                grid.showColumn('command');
            } else {
                grid.hideColumn('command');
            }
        }
    }

    showRoleDialog(role = null) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для выполнения этой операции.', 'warning');
            return;
        }

        const isEdit = !!role;
        const title = isEdit ? 'Редактирование роли' : 'Добавление роли';

        const dialog = $('#roleDialog').kendoDialog({
            width: '600px',
            title: title,
            closable: true,
            modal: true,
            visible: false,
            content: $('#role-dialog-template').html(),
            actions: [
                { text: 'Отмена' },
                { text: 'Сохранить', primary: true, action: () => this.saveRoleDialog(isEdit, role?.id) }
            ],
            open: () => {
                if (isEdit) {
                    $('#dialogRoleName').val(role.name);
                    $('#dialogRoleDescription').val(role.description);
                } else {
                    $('#dialogRoleName').val('');
                    $('#dialogRoleDescription').val('');
                }

                this.initPermissionsListInRole();
                if (isEdit) {
                    this.#apiService.getRolePermissions(role.id)
                        .done(permissions => {
                            permissions.forEach(permission => {
                                $(`#permission_${permission.id}`).prop('checked', true);
                            });
                            this.updateCategoryCheckboxes();
                        })
                        .fail(App.handleAjaxError);
                }
            }
        }).data('kendoDialog');

        dialog.open();
    }

    initPermissionsListInRole() {
        const permissionsContainer = $('#dialogPermissionsList');
        if (!permissionsContainer.length) {
            console.error('Permissions container not found');
            return;
        }

        // Clear existing content
        permissionsContainer.empty();

        this.#apiService.getPermissions()
            .done(permissions => {
                const permissionsByCategory = {};
                permissions.forEach(permission => {
                    if (!permissionsByCategory[permission.category]) {
                        permissionsByCategory[permission.category] = [];
                    }
                    permissionsByCategory[permission.category].push(permission);
                });

                this.renderDialogPermissionsList(permissionsByCategory);
                this.initializePermissionFilters();
            })
            .fail(App.handleAjaxError);
    }

    renderDialogPermissionsList(permissionsByCategory) {
        const permissionsContainer = $('#dialogPermissionsList');
        let html = '<div class="permissions-list">';

        for (const category in permissionsByCategory) {
            const categoryId = category.replace(/\s+/g, '_');
            html += `
                <div class="permission-category-section">
                    <div class="permission-category-header">
                        <label>
                            <input type="checkbox" class="category-checkbox" data-category="${categoryId}">
                            <span class="category-name">${kendo.htmlEncode(category)}</span>
                        </label>
                    </div>
                    <div class="permission-items category-permissions" data-category="${categoryId}">`;

            permissionsByCategory[category].forEach(permission => {
                html += `
                    <div class="permission-item">
                        <label>
                            <input type="checkbox" class="permission-checkbox"
                                   id="permission_${permission.id}"
                                   value="${permission.id}"
                                   data-category="${categoryId}">
                            <span class="permission-name">${kendo.htmlEncode(permission.name)}</span>
                        </label>
                    </div>`;
            });

            html += '</div></div>';
        }

        html += '</div>';
        permissionsContainer.html(html);

        // Initialize checkbox event handlers
        $('.category-checkbox').on('change', (e) => {
            const category = $(e.target).data('category');
            const isChecked = $(e.target).prop('checked');
            $(`.permission-checkbox[data-category="${category}"]`).prop('checked', isChecked);
        });

        $('.permission-checkbox').on('change', () => {
            this.updateCategoryCheckboxes();
        });
    }

    updateCategoryCheckboxes() {
        $('.category-checkbox').each((_, categoryCheckbox) => {
            const $categoryCheckbox = $(categoryCheckbox);
            const category = $categoryCheckbox.data('category');
            const $permissions = $(`.permission-checkbox[data-category="${category}"]`);
            const $checkedPermissions = $permissions.filter(':checked');
            $categoryCheckbox.prop('checked', $permissions.length === $checkedPermissions.length);
        });
    }

    initializePermissionFilters() {
        const categoryFilter = $('#dialogCategoryFilter');
        if (!categoryFilter.length) {
            console.error('Category filter not found');
            return;
        }

        // Get unique categories from rendered permissions
        const categories = ['Все категории', ...new Set(Array.from($('.category-name')).map(el => $(el).text().trim()))];

        categoryFilter.kendoDropDownList({
            dataSource: categories,
            value: 'Все категории',
            change: () => this.filterDialogPermissions()
        });

        // Initialize search input
        $('#dialogPermissionSearch').on('input', () => this.filterDialogPermissions());
    }

    filterDialogPermissions() {
        const searchTerm = $('#dialogPermissionSearch').val().toLowerCase();
        const selectedCategory = $('#dialogCategoryFilter').data('kendoDropDownList').value();

        $('.permission-category-section').each((_, categorySection) => {
            const $categorySection = $(categorySection);
            const categoryName = $categorySection.find('.category-name').text().trim();
            const $permissionItems = $categorySection.find('.permission-item');

            let hasVisibleItems = false;

            if (selectedCategory === 'Все категории' || categoryName === selectedCategory) {
                $permissionItems.each((_, item) => {
                    const $item = $(item);
                    const permissionName = $item.find('.permission-name').text().trim().toLowerCase();
                    const isVisible = permissionName.includes(searchTerm);
                    $item.toggle(isVisible);
                    if (isVisible) hasVisibleItems = true;
                });
            } else {
                hasVisibleItems = false;
            }

            $categorySection.toggle(hasVisibleItems);
        });
    }

    saveRoleDialog(isEdit, roleId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для сохранения роли.', 'warning');
            return false;
        }

        const name = $('#dialogRoleName').val();
        const description = $('#dialogRoleDescription').val();

        if (!name) {
            App.showNotification('Название роли обязательно для заполнения', 'error');
            return false;
        }

        const selectedPermissionIds = $('.permission-checkbox:checked').map(function () {
            return $(this).val();
        }).get();

        const roleData = {
            name: name,
            description: description
        };

        if (isEdit) {
            this.#apiService.updateRole(roleId, roleData)
                .done(() => {
                    this.#apiService.assignPermissionsToRole(roleId, selectedPermissionIds)
                        .done(() => {
                            $('#rolesGrid').data('kendoGrid').dataSource.read();
                            App.showNotification('Роль успешно обновлена', 'success');
                        })
                        .fail(App.handleAjaxError);
                })
                .fail(App.handleAjaxError);
        } else {
            this.#apiService.createRole({ ...roleData, permissionIds: selectedPermissionIds })
                .done(() => {
                    $('#rolesGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Роль успешно создана', 'success');
                })
                .fail(App.handleAjaxError);
        }

        return true;
    }

    deleteRole(roleId) {
        if (!this.#auth.isAdmin()) {
            App.showNotification('У вас нет прав для удаления роли.', 'warning');
            return;
        }

        if (confirm('Вы уверены, что хотите удалить эту роль?')) {
            this.#apiService.deleteRole(roleId)
                .done(() => {
                    $('#rolesGrid').data('kendoGrid').dataSource.read();
                    App.showNotification('Роль успешно удалена', 'success');
                })
                .fail(App.handleAjaxError);
        }
    }
}