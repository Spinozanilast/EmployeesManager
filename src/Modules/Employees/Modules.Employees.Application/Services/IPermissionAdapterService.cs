using Permissions.Application.Models.Shared;

namespace Employees.Application.Services;

/// <summary>
/// Интерфейс сервиса для работы с правами доступа в контексте сотрудников
/// </summary>
public interface IPermissionAdapterService
{
    /// <summary>
    /// Получает право доступа по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор права доступа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>DTO права доступа</returns>
    Task<PermissionDto> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default);
}