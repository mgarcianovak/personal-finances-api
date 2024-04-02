using PersonalFinances.API.Dtos;
using PersonalFinances.API.Entities;

namespace PersonalFinances.API.Mapping;

public static class TransactionMapping
{
    public static Transaction ToEntity(this CreateTransactionDto transaction)
    {
        return new Transaction()
        {
            Amount = transaction.Amount,
            CategoryId = transaction.CategoryId,
            Date = transaction.Date,
            Observation = transaction.Observation
        };
    }

    public static TransactionSummaryDto ToTransactionSummaryDto(this Transaction transaction)
    {
        return new TransactionSummaryDto(
            transaction.Id,
            transaction.Amount,
            transaction.Category!.Name,
            transaction.Date,
            transaction.Observation
        );
    }

    public static TransactionDetailsDto ToTransactionDetailsDto(this Transaction transaction)
    {
        return new TransactionDetailsDto(
            transaction.Id,
            transaction.Amount,
            transaction.CategoryId,
            transaction.Date,
            transaction.Observation
        );
    }

    public static Transaction ToEntity(this UpdateTransactionDto transaction, int id)
    {
        return new Transaction()
        {
            Id = id,
            Amount = transaction.Amount,
            CategoryId = transaction.CategoryId,
            Date = transaction.Date,
            Observation = transaction.Observation
        };
    }
}
