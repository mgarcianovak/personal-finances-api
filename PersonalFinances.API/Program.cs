using System.Transactions;
using PersonalFinances.API.Data;
using PersonalFinances.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("PersonalFinances");
builder.Services.AddSqlite<PersonalFinancesContext>(connString);

var app = builder.Build();

app.MapTransactionsEndpoints();
app.MapCategoriesEndpoints();

await app.MigrateDbAsync();

app.Run();