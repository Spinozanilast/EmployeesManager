class AuthModule {

    #isAdmin = false;
    #currentUser = {
        name: 'Пользователь',
        isAdmin: false
    };


    init() {

        const savedAdmin = localStorage.getItem('isAdmin');
        if (savedAdmin === 'true') {
            this.setAdminMode(true);
        } else {
            this.setAdminMode(false);
        }

        $('#loginBtn').on('click', () => {
            this.setAdminMode(true);
        });

        $('#logoutBtn').on('click', () => {
            this.setAdminMode(false);
        });

        this.updateUI();
    }

    setAdminMode(admin) {
        this.#isAdmin = admin;
        this.#currentUser.isAdmin = admin;
        this.#currentUser.name = admin ? 'Администратор' : 'Пользователь';

        localStorage.setItem('isAdmin', admin);

        this.updateUI();
        if (admin) {
            App.showNotification('Вы вошли как администратор', 'info');
        } else {
            App.showNotification('Вы вошли как пользователь', 'info');
        }
    }

    updateUI() {
        $('#userName').text(this.#currentUser.name);

        if (this.#isAdmin) {
            $('#loginBtn').hide();
            $('#logoutBtn').show();
            $('.admin-only').show();
        } else {
            $('#loginBtn').show();
            $('#logoutBtn').hide();
            $('.admin-only').hide();
        }
    }

    isAdmin() {
        return this.#isAdmin;
    }

    getCurrentUser() {
        return this.#currentUser;
    }
};
