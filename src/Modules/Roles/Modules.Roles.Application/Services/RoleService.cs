using Permissions.Application.Models.Shared;
using Permissions.Application.Services;
using Roles.Application.Extensions;
using Roles.Application.Models;
using Roles.Application.Models.Shared;
using Roles.Domain.Entities;
using Roles.Domain.Repositories;

namespace Roles.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRolesRepository _roleRepository;
    private readonly IPermissionService _permissionService;

    public RoleService(IRolesRepository roleRepository, IPermissionService permissionService)
    {
        _roleRepository = roleRepository;
        _permissionService = permissionService;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken = default)
    {
        var roles = await _roleRepository.GetAllAsync(cancellationToken);
        var result = new List<RoleDto>();

        foreach (var role in roles)
        {
            var roleDto = role.ToDto();
            var permissions = await GetRolePermissionsAsync(role.Id, cancellationToken);
            roleDto.Permissions = permissions;
            result.Add(roleDto);
        }

        return result;
    }

    public async Task<RoleDto> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);
        if (role is null)
        {
            throw new KeyNotFoundException($"Роль с идентификатором {id} не найдена");
        }

        var roleDto = role.ToDto();
        var permissions = await GetRolePermissionsAsync(id, cancellationToken);
        roleDto.Permissions = permissions;

        return roleDto;
    }

    public async Task<Guid> CreateRoleAsync(CreateRoleDto createRoleDto,
        CancellationToken cancellationToken = default)
    {
        var role = new Role(createRoleDto.Name, createRoleDto.Description);

        if (createRoleDto.PermissionIds is not null && createRoleDto.PermissionIds.Any())
        {
            foreach (var permissionId in createRoleDto.PermissionIds)
            {
                role.AddPermission(permissionId);
            }
        }

        await _roleRepository.AddAsync(role, cancellationToken);

        return role.Id;
    }

    public async Task UpdateRoleAsync(Guid id, UpdateRoleDto updateRoleDto,
        CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
        {
            throw new KeyNotFoundException($"Роль с идентификатором {id} не найдена");
        }

        role.Update(updateRoleDto.Name, updateRoleDto.Description);

        await _roleRepository.UpdateAsync(role, cancellationToken);
    }

    public async Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
        {
            throw new KeyNotFoundException($"Роль с идентификатором {id} не найдена");
        }

        await _roleRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task AssignPermissionsToRoleAsync(Guid roleId, IEnumerable<Guid> permissionIds,
        CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
        if (role is null)
        {
            throw new KeyNotFoundException($"Роль с идентификатором {roleId} не найдена");
        }

        role.ClearPermissions();

        foreach (var permissionId in permissionIds)
        {
            role.AddPermission(permissionId);
        }

        await _roleRepository.UpdateAsync(role, cancellationToken);
    }

    public async Task<IEnumerable<PermissionDto>> GetRolePermissionsAsync(Guid roleId,
        CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
        if (role is null)
        {
            throw new KeyNotFoundException($"Роль с идентификатором {roleId} не найдена");
        }

        var permissionIds = role.Permissions.Select(p => p.PermissionId).ToList();
        var permissions = await _permissionService.GetPermissionsByIdsAsync(permissionIds, cancellationToken);

        return permissions;
    }
}