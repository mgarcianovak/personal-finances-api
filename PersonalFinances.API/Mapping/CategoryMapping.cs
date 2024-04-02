using PersonalFinances.API.Entities;
using PersonalFinances.API.Dtos;


namespace PersonalFinances.API.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Name);
    }

    public static Category ToEntity(this CreateCategoryDto category)
    {
        return new Category()
        {
            Name = category.Name
        };
    }

    public static Category ToEntity(this UpdateCategoryDto category, int id)
    {
        return new Category()
        {
            Id = id,
            Name = category.Name
        };
    }
}
