using JobCostingAPI.Models;

namespace JobCostingAPI.Services;

public class JobCostingService
{
    private const decimal GstRate = 0.15m;

    public JobCostResponse Calculate(JobCostRequest request)
    {
        var labourCost = request.LabourHours * request.HourlyRate;
        var subtotal = labourCost + request.MaterialsCost + request.TravelCost;
        var markup = subtotal * (request.MarkupPercentage / 100);
        var beforeGst = subtotal + markup;
        var gst = request.IncludeGst ? beforeGst * GstRate : 0;
        var finalQuote = beforeGst + gst;

        return new JobCostResponse
        {
            LabourCost = decimal.Round(labourCost, 2),
            MaterialsCost = decimal.Round(request.MaterialsCost, 2),
            TravelCost = decimal.Round(request.TravelCost, 2),
            Subtotal = decimal.Round(subtotal, 2),
            Markup = decimal.Round(markup, 2),
            Gst = decimal.Round(gst, 2),
            FinalQuote = decimal.Round(finalQuote, 2),
            EstimatedProfit = decimal.Round(markup, 2)
        };
    }
}