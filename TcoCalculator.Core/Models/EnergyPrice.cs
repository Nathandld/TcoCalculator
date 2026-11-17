namespace TcoCalculator.Core.Models;

public class EnergyPrice
{
    public int Id { get; set; }
    public int Year { get; set; }
    public required string Region { get; set; }
    public required string EnergyVector { get; set; }
    public required string Unit { get; set; }
    public decimal PricePerUnit { get; set; }
}
