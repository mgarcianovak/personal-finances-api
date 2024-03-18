using System.Data;
using PersonalFinances.API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetTransactionEndpoint = "GetTransaction";

List<TransactionDto> transactions = [
    new (
        1,
        15000M,
        1,
        2,
        new DateOnly(2024, 2, 25),
        "Delivery"
    ),
    new (
        2,
        2350M,
        2,
        1,
        new DateOnly(2024, 2, 22),
        "Peluquería"
    ),
    new (
        3,
        50000M,
        5,
        1,
        new DateOnly(2024, 1, 30),
        "Aire acondicionado"
    )
];

app.MapGet("transactions", () => transactions);

app.MapGet("transactions/{id}", (int id) => transactions.Find(transaction => transaction.Id == id))
    .WithName(GetTransactionEndpoint);

app.MapPost("transactions", (CreateTransactionDto newTransaction) =>
{
    TransactionDto transaction = new(
        transactions.Count + 1,
        newTransaction.Amount,
        newTransaction.CategoryId,
        newTransaction.AccountId,
        newTransaction.Date,
        newTransaction.Observation
    );

    transactions.Add(transaction);

    return Results.CreatedAtRoute(GetTransactionEndpoint, new { id = transaction.Id }, transaction);
});

app.MapGet("/", () => "Hello World!");

app.Run();