namespace JobCostingAPI.Models;

public class JobCostResponse
{
    public decimal LabourCost { get; set; }
    public decimal MaterialsCost { get; set; }
    public decimal TravelCost { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Markup { get; set; }
    public decimal Gst { get; set; }
    public decimal FinalQuote { get; set; }
    public decimal EstimatedProfit { get; set; }
}