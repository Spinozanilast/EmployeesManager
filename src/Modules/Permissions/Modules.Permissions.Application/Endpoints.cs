using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Permissions.Application.Models;
using Permissions.Application.Services;

namespace Permissions.Application;

public static class PermissionsEndpoints
{
    public static void MapPermissionsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/permissions")
            .WithTags("Permissions")
            .WithOpenApi();

        group.MapGet("/", async (
                    [FromServices] IPermissionService service) =>
                Results.Ok(await service.GetAllPermissionsAsync()))
            .WithName("GetPermissions");

        group.MapGet("/category/{category}", async (
                    [FromRoute] string category,
                    [FromServices] IPermissionService service) =>
                Results.Ok(await service.GetPermissionsByCategoryAsync(category)))
            .WithName("GetPermissionsByCategory");

        group.MapGet("/{id:guid}", async (
                [FromRoute] Guid id,
                [FromServices] IPermissionService service) =>
            {
                try
                {
                    return Results.Ok(await service.GetPermissionByIdAsync(id));
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("GetPermissionById");

        group.MapGet("/search", async (
                    [FromQuery] string searchTerm,
                    [FromServices] IPermissionService service) =>
                Results.Ok(await service.SearchPermissionsByNameAsync(searchTerm)))
            .WithName("SearchPermissionsByName");

        group.MapPost("/", async (
                [FromBody] CreatePermissionDto dto,
                [FromServices] IPermissionService service) =>
            {
                var id = await service.CreatePermissionAsync(dto);
                return Results.Created($"/api/permissions/{id}", id);
            })
            .WithName("CreatePermission");

        group.MapPut("/{id:guid}", async (
                [FromRoute] Guid id,
                [FromBody] UpdatePermissionDto dto,
                [FromServices] IPermissionService service) =>
            {
                try
                {
                    await service.UpdatePermissionAsync(id, dto);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("UpdatePermission");

        group.MapDelete("/{id:guid}", async (
                [FromRoute] Guid id,
                [FromServices] IPermissionService service) =>
            {
                try
                {
                    await service.DeletePermissionAsync(id);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeletePermission");
    }
}