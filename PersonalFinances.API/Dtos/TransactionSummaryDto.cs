using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.API.Dtos;

public record class TransactionSummaryDto(
    int Id,
    [Range(1, 9999999)] decimal Amount,
    string Category,
    [Required] DateOnly Date,
    string? Observation
    );