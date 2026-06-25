namespace JobCostingAPI.Models
{
    public class JobCostRequest
    {
        public decimal LabourHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal MaterialsCost { get; set; }
        public decimal TravelCost { get; set; }
        public decimal MarkupPercentage { get; set; }
        public bool IncludeGst { get; set; } = true;
    }
}