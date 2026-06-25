using JobCostingAPI.Models;
using JobCostingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<JobCostingService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "https://black-tree-0958b2810.7.azurestaticapps.net"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapGet("/", () => Results.Ok(new
{
    app = "Job Costing API",
    status = "Running",
    version = "1.0.0"
}));

app.MapPost("/api/job-costing/calculate", (
    JobCostRequest request,
    JobCostingService jobCostingService) =>
{
    if (request.LabourHours < 0 ||
        request.HourlyRate < 0 ||
        request.MaterialsCost < 0 ||
        request.TravelCost < 0 ||
        request.MarkupPercentage < 0)
    {
        return Results.BadRequest(new
        {
            error = "Input values cannot be negative."
        });
    }

    var result = jobCostingService.Calculate(request);

    return Results.Ok(result);
});

app.Run();