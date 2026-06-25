# Job Costing API

A simple .NET Web API for calculating job costs, markup, GST, final quote amount, and estimated profit.

This API is designed as a practical starting point for tradies, freelancers, service businesses, and small business applications that need quick job cost estimation.

## Live API

Production URL:

```text
https://ruwan-first-app.azurewebsites.net/
```

> Replace this URL if your Azure App Service URL is different.

## Tech Stack

* .NET 10
* ASP.NET Core Web API
* Minimal API
* Azure App Service
* GitHub deployment

## API Status

### Health Check

Checks whether the API is running.

```http
GET /
```

### Example Response

```json
{
  "app": "Job Costing API",
  "status": "Running",
  "version": "1.0.0"
}
```

## Calculate Job Cost

Calculates labour cost, materials cost, travel cost, subtotal, markup, GST, final quote, and estimated profit.

### Endpoint

```http
POST /api/job-costing/calculate
```

### Full URL

```text
https://ruwan-first-app.azurewebsites.net/api/job-costing/calculate
```

## Request Body

```json
{
  "labourHours": 12,
  "hourlyRate": 85,
  "materialsCost": 450,
  "travelCost": 60,
  "markupPercentage": 25,
  "includeGst": true
}
```

## Request Fields

| Field              | Type    | Required | Description                                 |
| ------------------ | ------- | -------- | ------------------------------------------- |
| `labourHours`      | decimal | Yes      | Number of labour hours required for the job |
| `hourlyRate`       | decimal | Yes      | Labour charge per hour                      |
| `materialsCost`    | decimal | Yes      | Total cost of materials                     |
| `travelCost`       | decimal | Yes      | Travel, call-out, or transport cost         |
| `markupPercentage` | decimal | Yes      | Markup percentage added to the subtotal     |
| `includeGst`       | boolean | Yes      | Whether to include GST in the final quote   |

## Successful Response

```json
{
  "labourCost": 1020,
  "materialsCost": 450,
  "travelCost": 60,
  "subtotal": 1530,
  "markup": 382.5,
  "gst": 286.88,
  "finalQuote": 2199.38,
  "estimatedProfit": 382.5
}
```

## Response Fields

| Field             | Description                                |
| ----------------- | ------------------------------------------ |
| `labourCost`      | Labour hours multiplied by hourly rate     |
| `materialsCost`   | Material cost from the request             |
| `travelCost`      | Travel cost from the request               |
| `subtotal`        | Labour cost + materials cost + travel cost |
| `markup`          | Markup amount calculated from subtotal     |
| `gst`             | GST amount if GST is included              |
| `finalQuote`      | Final amount to quote the customer         |
| `estimatedProfit` | Estimated profit based on markup           |

## Error Response

If any numeric value is negative, the API returns a bad request response.

### Status Code

```http
400 Bad Request
```

### Example Response

```json
{
  "error": "Input values cannot be negative."
}
```

## Example Usage

### PowerShell

```powershell
$body = @{
    labourHours = 12
    hourlyRate = 85
    materialsCost = 450
    travelCost = 60
    markupPercentage = 25
    includeGst = $true
} | ConvertTo-Json

Invoke-RestMethod `
  -Uri "https://ruwan-first-app.azurewebsites.net/api/job-costing/calculate" `
  -Method Post `
  -Body $body `
  -ContentType "application/json"
```

### JavaScript Fetch

```javascript
const response = await fetch("https://ruwan-first-app.azurewebsites.net/api/job-costing/calculate", {
  method: "POST",
  headers: {
    "Content-Type": "application/json"
  },
  body: JSON.stringify({
    labourHours: 12,
    hourlyRate: 85,
    materialsCost: 450,
    travelCost: 60,
    markupPercentage: 25,
    includeGst: true
  })
});

const data = await response.json();
console.log(data);
```

### cURL

```bash
curl -X POST "https://ruwan-first-app.azurewebsites.net/api/job-costing/calculate" \
  -H "Content-Type: application/json" \
  -d '{
    "labourHours": 12,
    "hourlyRate": 85,
    "materialsCost": 450,
    "travelCost": 60,
    "markupPercentage": 25,
    "includeGst": true
  }'
```

## Running Locally

### Prerequisites

Install the .NET 10 SDK.

Check your installed SDK:

```powershell
dotnet --list-sdks
```

### Run the API

```powershell
dotnet run
```

The terminal will show a local URL similar to:

```text
http://localhost:5123
```

Test the health check endpoint:

```text
http://localhost:5123/
```

Test the job costing endpoint:

```text
http://localhost:5123/api/job-costing/calculate
```

## Project Structure

```text
JobCostingAPI/
  Models/
    JobCostRequest.cs
    JobCostResponse.cs

  Services/
    JobCostingService.cs

  Program.cs
  appsettings.json
  appsettings.Development.json
  JobCostingAPI.csproj
```

## Current Features

* Calculate labour cost
* Calculate material and travel cost
* Calculate subtotal
* Calculate markup
* Calculate GST
* Calculate final quote
* Estimate profit
* Validate negative input values

## Future Improvements

Possible future features:

* API key authentication
* Quote PDF generation
* Multiple line items
* Different GST/tax settings
* Save quote history
* Customer and job records
* Database integration
* Swagger UI documentation
* Subscription-based API usage tracking

## Deployment

This project is deployed to Azure App Service using GitHub deployment.

Basic development workflow:

```powershell
git add .
git commit -m "Describe the change"
git push
```

After pushing to GitHub, Azure App Service redeploys the latest version automatically.
