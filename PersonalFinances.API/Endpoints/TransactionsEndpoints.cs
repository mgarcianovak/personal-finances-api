using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PersonalFinances.API.Data;
using PersonalFinances.API.Dtos;
using PersonalFinances.API.Entities;
using PersonalFinances.API.Mapping;

namespace PersonalFinances.API.Endpoints;

public static class TransactionsEndpoints
{
    const string GetTransactionEndpoint = "GetTransaction";

    public static RouteGroupBuilder MapTransactionsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transactions")
                        .WithParameterValidation();

        group.MapGet("/", async (PersonalFinancesContext dbContext) =>
            await dbContext.Transactions
                     .Include(transaction => transaction.Category)
                     .Select(transaction => transaction.ToTransactionSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        group.MapGet("/{id}", async (int id, PersonalFinancesContext dbContext) =>
        {
            Transaction? transaction = await dbContext.Transactions.FindAsync(id);

            return transaction is null ?
                Results.NotFound() : Results.Ok(transaction.ToTransactionDetailsDto());
        }
         ).WithName(GetTransactionEndpoint);

        group.MapPost("/", async (CreateTransactionDto newTransaction, PersonalFinancesContext dbContext) =>
        {
            Transaction transaction = newTransaction.ToEntity();

            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute
                (GetTransactionEndpoint,
                new { id = transaction.Id },
                transaction.ToTransactionDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateTransactionDto updatedTransaction, PersonalFinancesContext dbContext) =>
        {
            Transaction? transactionToUpdate = await dbContext.Transactions.FindAsync(id);

            if (transactionToUpdate is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(transactionToUpdate)
                     .CurrentValues
                     .SetValues(updatedTransaction.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, PersonalFinancesContext dbContext) =>
        {
            await dbContext.Transactions
                     .Where(transaction => transaction.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
