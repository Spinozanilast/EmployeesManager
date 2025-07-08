class ApiService {
    #apiBaseUrl;
    constructor(apiUrl) {
        this.#apiBaseUrl = apiUrl;
    }

    // ---------- Employees ----------
    getEmployees() {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees`,
            method: 'GET'
        });
    }

    getEmployeeById(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}`,
            method: 'GET'
        });
    }

    createEmployee(employeeData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(employeeData)
        });
    }

    updateEmployee(id, employeeData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(employeeData)
        });
    }

    deleteEmployee(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}`,
            method: 'DELETE'
        });
    }

    getEmployeeRoles(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}/roles`,
            method: 'GET'
        });
    }

    getEmployeePermissions(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}/permissions`,
            method: 'GET'
        });
    }

    assignRolesToEmployee(id, roleIds) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/employees/${id}/roles`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(roleIds)
        });
    }

    // ---------- Roles ----------
    getRoles() {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles`,
            method: 'GET'
        });
    }

    getRoleById(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles/${id}`,
            method: 'GET'
        });
    }

    createRole(roleData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(roleData)
        });
    }

    updateRole(id, roleData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles/${id}`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(roleData)
        });
    }

    deleteRole(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles/${id}`,
            method: 'DELETE'
        });
    }

    // ---------- Permissions ----------
    getPermissions() {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions`,
            method: 'GET'
        });
    }

    getPermissionById(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions/${id}`,
            method: 'GET'
        });
    }

    createPermission(permissionData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(permissionData)
        });
    }

    updatePermission(id, permissionData) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions/${id}`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(permissionData)
        });
    }

    deletePermission(id) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions/${id}`,
            method: 'DELETE'
        });
    }

    getPermissionsByCategories(category) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/permissions/category/${category}`,
            method: 'GET'
        });
    }

    // ---------- Role Permissions ----------
    getRolePermissions(roleId) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles/${roleId}/permissions`,
            method: 'GET'
        });
    }

    assignPermissionsToRole(roleId, permissionIds) {
        return $.ajax({
            url: `${this.#apiBaseUrl}/roles/${roleId}/permissions`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(permissionIds)
        });
    }
}