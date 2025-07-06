using Permissions.Application.Models.Shared;

namespace Roles.Application.Services;

/// <summary>
/// Интерфейс сервиса для работы с правами доступа в контексте ролей
/// </summary>
public interface IPermissionAdapterService
{
    /// <summary>
    /// Получить права доступа по списку идентификаторов
    /// </summary>
    Task<IEnumerable<PermissionDto>> GetPermissionsByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}