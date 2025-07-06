using Employees.Application.Models;
using Employees.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Employees.Application;

public static class EmployeesEndpoints
{
    public static void MapEmployeesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/employees")
            .WithTags("Employees")
            .WithOpenApi();

        group.MapGet("/", async (
                    [FromServices] IEmployeeService service) =>
                await service.GetAllEmployeesAsync())
            .WithName("GetAllEmployees");

        group.MapGet("/{id:guid}", async (
                [FromRoute] Guid id,
                [FromServices] IEmployeeService service) =>
            {
                try
                {
                    return Results.Ok(await service.GetEmployeeByIdAsync(id));
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("GetEmployeeById");

        group.MapGet("/search", async (
                    [FromQuery] string searchTerm,
                    IEmployeeService service) =>
                Results.Ok(await service.SearchEmployeesByNameAsync(searchTerm)))
            .WithName("SearchEmployeesByName");

        group.MapGet("/role/{roleId:guid}", async (
                    [FromRoute] Guid roleId,
                    [FromServices] IEmployeeService service) =>
                Results.Ok(await service.GetEmployeesByRoleIdAsync(roleId)))
            .WithName("GetEmployeeByRoleId");

        group.MapPost("/", async (
                [FromBody] CreateEmployeeDto dto,
                [FromServices] IEmployeeService service) =>
            {
                var id = await service.CreateEmployeeAsync(dto);
                return Results.Created($"/api/employees/{id}", id);
            })
            .WithName("CreateEmployee");

        group.MapPut("/{id:guid}",
                async (
                    [FromRoute] Guid id,
                    [FromBody] UpdateEmployeeDto dto,
                    [FromServices] IEmployeeService service) =>
                {
                    try
                    {
                        await service.UpdateEmployeeAsync(id, dto);
                        return Results.NoContent();
                    }
                    catch (KeyNotFoundException ex)
                    {
                        return Results.NotFound(ex.Message);
                    }
                })
            .WithName("UpdateEmployee");

        group.MapDelete("/{id:guid}", async (
                [FromRoute] Guid id,
                [FromServices] IEmployeeService service) =>
            {
                try
                {
                    await service.DeleteEmployeeAsync(id);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeleteEmployee");

        group.MapGet("/{id:guid}/roles", async (
                [FromRoute] Guid id,
                [FromServices] IEmployeeService service) =>
            {
                try
                {
                    return Results.Ok(await service.GetEmployeeRolesAsync(id));
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("GetEmployeeRoles");

        group.MapPost("/{id:guid}/roles", async (
                [FromRoute] Guid id,
                [FromBody] IEnumerable<Guid> roleIds,
                [FromServices] IEmployeeService service) =>
            {
                try
                {
                    await service.AssignRolesToEmployeeAsync(id, roleIds);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("AssignRolesToEmployee");

        group.MapGet("/{id:guid}/permissions", async (
                [FromRoute] Guid id,
                [FromServices] IEmployeeService service) =>
            {
                try
                {
                    return Results.Ok(await service.GetEmployeePermissionsAsync(id));
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("GetEmployeePermissions");
    }
}