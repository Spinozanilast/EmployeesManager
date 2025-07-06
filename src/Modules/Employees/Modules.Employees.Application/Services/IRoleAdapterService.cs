using Roles.Application.Models.Shared;

namespace Employees.Application.Services;

/// <summary>
/// Интерфейс сервиса для работы с ролями в контексте сотрудников
/// </summary>
public interface IRoleAdapterService
{
    /// <summary>
    /// Получить роль по идентификатору
    /// </summary>
    Task<RoleDto> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить роли по списку идентификаторов
    /// </summary>
    Task<IEnumerable<RoleDto>> GetRolesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}