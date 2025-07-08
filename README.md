# Employees rights and roles manager mini app

[Веб-проект](https://github.com/Spinozanilast/EmployeesManager/tree/web-app/src/EmployeesManager.Web)

## Как запускать

### Через Docker

0. Вставить лицензионный ключ Kendo Ui в [env.dev.js] (https://github.com/Spinozanilast/EmployeesManager/tree/web-app/src/EmployeesManager.Web/js/env.dev.js)

KendoLicensing.setScriptKey("xxxxx")

1. Запускаем Docker (или другой like docker-compose клиент) и находясь в корне проекта исполняем следующую команду в терминале:

```bash 
docker compose up 
```

### С уже запущенным сервером PostgreSQL

0. Вставить лицензионный ключ Kendo Ui в [env.dev.js] веб-проекта (https://github.com/Spinozanilast/EmployeesManager/tree/web-app/src/EmployeesManager.Web/js/env.dev.js)

KendoLicensing.setScriptKey("xxxxx")

1. Если сервер базы данных использует порт 5432, то ничего менять не нужно, если другой - то поменять конфигурацию в
   docker-compose.yml или в конфигурации проекта
2. Запускаем проект (или создаём контейнер)
3. Открываем
   index.html [веб-проекта](https://github.com/Spinozanilast/EmployeesManager/tree/web-app/src/EmployeesManager.Web) в
   браузере

## Скриншоты

### Веб - Админ

<div align="center">

#### Страница с сотрудниками
![employees-admin](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/employees-admin.png)

#### Страница с ролями
![roles-admin](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/roles-admin.png)

#### Страница с правами 
![permissions-admin](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/permissions-admin.png)

#### Страница с сотрудником
![employee-view-admin](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/employee-view-admin.png)

</div>

### Веб - Сотрудник

<div align="center">

#### Страница с сотрудниками
![employees-employee](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/employees-employee.png)

#### Страница с сотрудником
![employee-view-employee](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/employee-view-employee.png)

</div>

### API

#### Модуль Employees
![api-employees](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/api-employees.png)

#### Модуль Roles
![api-roles](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/api-roles.png)

#### Модуль Permissions
![api-roles](https://raw.githubusercontent.com/Spinozanilast/EmployeesManager/refs/heads/master/screenshots/api-permissions.png)