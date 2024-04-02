using System.Diagnostics;

namespace PersonalFinances.API.Entities;

public class Transaction
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public DateOnly Date { get; set; }

    public string? Observation { get; set; }
}
