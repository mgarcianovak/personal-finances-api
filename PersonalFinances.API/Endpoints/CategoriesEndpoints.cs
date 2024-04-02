using Microsoft.EntityFrameworkCore;
using PersonalFinances.API.Data;
using PersonalFinances.API.Dtos;
using PersonalFinances.API.Entities;
using PersonalFinances.API.Mapping;

namespace PersonalFinances.API.Endpoints;

public static class CategoriesEndpoints
{
    const string GetCategoryEndpoint = "GetCategory";

    public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories");

        group.MapGet("/", async (PersonalFinancesContext dbContext) =>
            await dbContext.Categories
                            .Select(category => category.ToDto())
                            .AsNoTracking()
                            .ToListAsync());

        group.MapGet("/{id}", async (int id, PersonalFinancesContext dbContext) =>
        {
            Category? category = await dbContext.Categories.FindAsync(id);

            return category is null ?
                Results.NotFound() : Results.Ok(category.ToDto());
        }
         ).WithName(GetCategoryEndpoint);

        group.MapPost("/", async (CreateCategoryDto newCategory, PersonalFinancesContext dbContext) =>
        {
            Category category = newCategory.ToEntity();

            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute
                (GetCategoryEndpoint,
                new { id = category.Id },
                category.ToDto());
        });

        group.MapPut("/{id}", async (int id, UpdateCategoryDto updatedCategory, PersonalFinancesContext dbContext) =>
        {
            Category? categoryToUpdate = await dbContext.Categories.FindAsync(id);

            if (categoryToUpdate is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(categoryToUpdate)
                     .CurrentValues
                     .SetValues(updatedCategory.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, PersonalFinancesContext dbContext) =>
        {
            await dbContext.Categories
                     .Where(category => category.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
