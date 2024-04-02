using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.API.Dtos;

public record class TransactionDetailsDto(
    int Id,
    [Range(1, 9999999)] decimal Amount,
    int CategoryId,
    [Required] DateOnly Date,
    string? Observation
    );