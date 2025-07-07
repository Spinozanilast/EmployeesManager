class App {
    currentPage = 'employees';

    #mainContentContainer = null;
    #auth = new AuthModule();

    #dataCache = {
        employees: [],
        roles: [],
        permissions: []
    };

    #employeeModule;
    #roleModule;
    #permissionModule;

    constructor() {
        const apiService = new ApiService(API_URL);

        this.#employeeModule = new EmployeeModule(apiService, this.#auth, this.#dataCache, this.navigateTo.bind(this));
        this.#roleModule = new RoleModule(apiService, this.#auth, this.#dataCache);
        this.#permissionModule = new PermissionModule(apiService, this.#auth, this.#dataCache);

        this.ensureDialogsCreated();
    }

    init() {
        this.#mainContentContainer = $('#mainContentArea');
        this.currentPage = localStorage.getItem('lastVisitedPage') || this.currentPage;

        this.#auth.init(this.updateUIForRole.bind(this));

        this.setupNavigation();
        this.loadInitialData();

        this.navigateTo(this.currentPage);
    }

    ensureDialogsCreated() {
        if (!$('#employeeDialog').length) {
            $('body').append('<div id="employeeDialog"></div>');
        }
        if (!$('#roleDialog').length) {
            $('body').append('<div id="roleDialog"></div>');
        }
        if (!$('#permissionDialog').length) {
            $('body').append('<div id="permissionDialog"></div>');
        }
    }

    setupNavigation() {
        $('.nav-item').on('click', (e) => {
            const page = $(e.currentTarget).data('page');
            if ($(e.currentTarget).hasClass('admin-only') && !this.#auth.isAdmin()) {
                this.showNotification('У вас нет прав для доступа к этой странице.', 'warning');
                return;
            }
            this.navigateTo(page);
        });

        $(document).on('click', '#backToEmployeesBtn', () => this.navigateTo('employees'));
        $(document).on('click', '#backToRolesBtn', () => this.navigateTo('roles'));
    }

    loadInitialData() {
        const apiService = new ApiService(API_URL);

        apiService.getEmployees()
            .done(data => this.#dataCache.employees = data)
            .fail(this.handleAjaxError);

        apiService.getRoles()
            .done(data => this.#dataCache.roles = data)
            .fail(this.handleAjaxError);

        apiService.getPermissions()
            .done(data => this.#dataCache.permissions = data)
            .fail(this.handleAjaxError);
    }

    navigateTo(page) {
        this.#mainContentContainer.empty();
        $('.nav-item').removeClass('active');

        const pageConfig = this.#getPageConfig(page);
        if (!pageConfig) {
            console.error('Unknown page:', page);
            return;
        }

        const pageContentHtml = $(pageConfig.templateId).html();
        const newPageDiv = $(`<div id="${pageConfig.containerId}" class="page active"></div>`).html(pageContentHtml);
        this.#mainContentContainer.append(newPageDiv);

        $(`.nav-item[data-page="${page}"]`).addClass('active');
        this.currentPage = page;

        localStorage.setItem('lastVisitedPage', page);

        this.#initializePage(page);
        this.updateUIForRole();
    }

    #getPageConfig(page) {
        const configs = {
            'employees': { templateId: '#employees-template', containerId: 'employees-page' },
            'roles': { templateId: '#roles-template', containerId: 'roles-page' },
            'permissions': { templateId: '#permissions-template', containerId: 'permissions-page' },
            'employee-details': { templateId: '#employee-details-template', containerId: 'employee-details-page' },
            'role-edit': { templateId: '#role-edit-template', containerId: 'role-edit-page' }
        };
        return configs[page];
    }

    #initializePage(page) {
        switch (page) {
            case 'employees':
                this.#employeeModule.initEmployeesPage();
                break;
            case 'roles':
                this.#roleModule.initRolesPage();
                break;
            case 'permissions':
                this.#permissionModule.initPermissionsPage();
                break;
        }
    }

    updateUIForRole() {
        const isAdmin = this.#auth.isAdmin();
        const currentPageDiv = $(`#${this.currentPage}-page`, this.#mainContentContainer);

        $('.nav-item.admin-only').toggle(isAdmin);

        $('.page-actions .admin-only', currentPageDiv).toggle(isAdmin);
        $('.page-header.admin-only', currentPageDiv).toggle(isAdmin);
        $('.filter-panel.admin-only', currentPageDiv).toggle(isAdmin);
        $('#employee-details-page .admin-only', currentPageDiv).toggle(isAdmin);
        $('#employeeRolesSection .admin-only', currentPageDiv).toggle(isAdmin);
        $('#role-edit-page .admin-only', currentPageDiv).toggle(isAdmin);

        if (this.currentPage === 'employees') {
            this.#employeeModule.updateGridColumnVisibility();
        } else if (this.currentPage === 'roles') {
            this.#roleModule.updateGridColumnVisibility();
        } else if (this.currentPage === 'permissions') {
            this.#permissionModule.updateGridColumnVisibility();
        }

        if (!isAdmin) {
            const currentNavDataPage = $('.nav-menu .nav-item.active').data('page');
            if (currentNavDataPage !== 'employees' && currentNavDataPage !== 'employee-details') {
                this.navigateTo('employees');
            }
        }
    }

    static showNotification(message, type = 'info') {
        const notification = $('<div>').addClass(`notification ${type}`).text(message);
        $('body').append(notification);
        notification.fadeIn();
        setTimeout(() => notification.fadeOut(() => notification.remove()), 2000);
    }

    static handleAjaxError(xhr) {
        console.error('Ajax error:', xhr);
        const message = xhr.responseJSON?.message || 'Произошла ошибка при выполнении запроса.';
        this.showNotification(message, 'error');
    }
}

$(document).ready(() => {
    const app = new App();
    app.init();
});