using Permissions.Application.Extensions;
using Permissions.Application.Models;
using Permissions.Application.Models.Shared;
using Permissions.Domain.Entities;
using Permissions.Domain.Repositories;

namespace Permissions.Application.Services;

public class 
    PermissionService : IPermissionService
{
    private readonly IPermissionsRepository _permissionRepository;

    public PermissionService(IPermissionsRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync(CancellationToken cancellationToken = default)
    {
        var permissions = await _permissionRepository.GetAllAsync(cancellationToken);
        return permissions.Select(PermissionsMapping.MapToDto);
    }

    public async Task<IEnumerable<PermissionDto>> GetPermissionsByCategoryAsync(string category,
        CancellationToken cancellationToken = default)
    {
        var permissions = await _permissionRepository.GetByCategoryAsync(category, cancellationToken);
        return permissions.Select(PermissionsMapping.MapToDto);
    }

    public async Task<PermissionDto> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);

        if (permission is null)
        {
            throw new KeyNotFoundException($"Право доступа с идентификатором {id} не найдено");
        }

        return permission.ToDto();
    }

    public async Task<IEnumerable<PermissionDto>> GetPermissionsByIdsAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        var result = new List<PermissionDto>();

        foreach (var id in ids)
        {
            try
            {
                var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
                if (permission != null)
                {
                    result.Add(permission.ToDto());
                }
            }
            catch (KeyNotFoundException)
            {
            }
        }

        return result;
    }

    public async Task<IEnumerable<PermissionDto>> SearchPermissionsByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default)
    {
        var permissions = await _permissionRepository.SearchByNameAsync(searchTerm, cancellationToken);
        return permissions.Select(PermissionsMapping.MapToDto);
    }

    public async Task<Guid> CreatePermissionAsync(CreatePermissionDto createPermissionDto,
        CancellationToken cancellationToken = default)
    {
        var permission = new Permission(
            createPermissionDto.Name,
            createPermissionDto.Description,
            createPermissionDto.Category);

        await _permissionRepository.AddAsync(permission, cancellationToken);

        return permission.Id;
    }

    public async Task UpdatePermissionAsync(Guid id, UpdatePermissionDto updatePermissionDto,
        CancellationToken cancellationToken = default)
    {
        var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
        if (permission is null)
        {
            throw new KeyNotFoundException($"Право доступа с идентификатором {id} не найдено");
        }

        permission.Update(
            updatePermissionDto.Name,
            updatePermissionDto.Description,
            updatePermissionDto.Category);

        await _permissionRepository.UpdateAsync(permission, cancellationToken);
    }

    public async Task DeletePermissionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
        if (permission is null)
        {
            throw new KeyNotFoundException($"Право доступа с идентификатором {id} не найдено");
        }

        await _permissionRepository.DeleteAsync(id, cancellationToken);
    }
}