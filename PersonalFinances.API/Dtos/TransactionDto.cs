namespace PersonalFinances.API.Dtos;

public record class TransactionDto(
    int Id, 
    decimal Amount, 
    int CategoryId, 
    int AccountId, 
    DateOnly Date, 
    string Observation
    );