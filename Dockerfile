FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EmployeesManager.API/EmployeesManager.API.csproj", "src/EmployeesManager.API/"]
COPY ["src/EmployeesManager.Infrastructure.Shared/EmployeesManager.Infrastructure.Shared.csproj", "src/EmployeesManager.Infrastructure.Shared/"]
COPY ["src/Modules/Employees/Modules.Employees.Application/Modules.Employees.Application.csproj", "src/Modules/Employees/Modules.Employees.Application/"]
COPY ["src/Modules/Employees/Modules.Employees.Domain/Modules.Employees.Domain.csproj", "src/Modules/Employees/Modules.Employees.Domain/"]
COPY ["src/Modules/Employees/Modules.Employees.Infrastructure/Modules.Employees.Infrastructure.csproj", "src/Modules/Employees/Modules.Employees.Infrastructure/"]
COPY ["src/Modules/Permissions/Modules.Permissions.Application/Modules.Permissions.Application.csproj", "src/Modules/Permissions/Modules.Permissions.Application/"]
COPY ["src/Modules/Permissions/Modules.Permissions.Domain/Modules.Permissions.Domain.csproj", "src/Modules/Permissions/Modules.Permissions.Domain/"]
COPY ["src/Modules/Permissions/Modules.Permissions.Infrastructure/Modules.Permissions.Infrastructure.csproj", "src/Modules/Permissions/Modules.Permissions.Infrastructure/"]
COPY ["src/Modules/Roles/Modules.Roles.Application/Modules.Roles.Application.csproj", "src/Modules/Roles/Modules.Roles.Application/"]
COPY ["src/Modules/Roles/Modules.Roles.Domain/Modules.Roles.Domain.csproj", "src/Modules/Roles/Modules.Roles.Domain/"]
COPY ["src/Modules/Roles/Modules.Roles.Infrastructure/Modules.Roles.Infrastructure.csproj", "src/Modules/Roles/Modules.Roles.Infrastructure/"]
COPY . .
RUN dotnet restore "src/EmployeesManager.API/EmployeesManager.API.csproj"
WORKDIR "/src/src/EmployeesManager.API"
RUN dotnet build "./EmployeesManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmployeesManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesManager.API.dll"]
