namespace PersonalFinances.API.Dtos;

public record class CreateTransactionDto(
    decimal Amount, 
    int CategoryId, 
    int AccountId, 
    DateOnly Date, 
    string Observation
    );