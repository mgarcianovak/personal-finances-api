using Microsoft.EntityFrameworkCore;

namespace PersonalFinances.API.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PersonalFinancesContext>();
        await dbContext.Database.MigrateAsync();
    }
}
