using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Roles.Application.Models;
using Roles.Application.Services;

namespace Roles.Application;

public static class RolesEndpoints
{
    public static void MapRolesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/roles")
            .WithTags("Roles")
            .WithOpenApi();

        group.MapGet("/", async ([FromServices] IRoleService service) =>
        Results.Ok(await service.GetAllRolesAsync()));

        group.MapGet("/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] IRoleService service) =>
        {
            try
            {
                return Results.Ok(await service.GetRoleByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapPost("/", async (
            [FromBody] CreateRoleDto dto,
            [FromServices] IRoleService service) =>
        {
            var id = await service.CreateRoleAsync(dto);
            return Results.Created($"/api/roles/{id}", id);
        });

        group.MapPut("/{id:guid}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateRoleDto dto,
            [FromServices] IRoleService service) =>
        {
            try
            {
                await service.UpdateRoleAsync(id, dto);
                return Results.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapDelete("/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] IRoleService service) =>
        {
            try
            {
                await service.DeleteRoleAsync(id);
                return Results.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapGet("/{id:guid}/permissions", async (
            [FromRoute] Guid id,
            [FromServices] IRoleService service) =>
        {
            try
            {
                return Results.Ok(await service.GetRolePermissionsAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapPost("/{id:guid}/permissions",
            async (
                [FromRoute] Guid id,
                [FromBody] IEnumerable<Guid> permissionIds,
                [FromServices] IRoleService service) =>
            {
                try
                {
                    await service.AssignPermissionsToRoleAsync(id, permissionIds);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
    }
}