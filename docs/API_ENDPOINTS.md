# API Endpoints

The ASP.NET Core API is currently exposed by `QuasarQuant.API`. The examples below use `http://localhost:5272`; use the HTTPS profile when required.

## Health

### `GET /health`

Returns a small operational response.

```json
{
  "status": "Healthy",
  "statusCode": 200,
  "message": "API is operational.",
  "responseTime": "0.01 ms",
  "timestamp": "2026-09-01T12:34:56Z"
}
```

## Signals

### `GET /api/signal/{symbol}`

Returns the latest signal for one market symbol.

Example:

```bash
curl http://localhost:5272/api/signal/AAPL
```

The current in-memory repository returns sample data for `AAPL` and `MSFT`. Other symbols return `404 Not Found`.

| Situation | Response |
|---|---|
| Known symbol | `200 OK` with a `TradeSignal` object |
| Unknown symbol | `404 Not Found` |
| Empty symbol | `400 Bad Request` |

### `POST /api/signal/batch`

Returns the latest available signals for a list of symbols.

Request body:

```json
["AAPL", "MSFT", "aapl"]
```

The API trims, uppercases, removes empty values, and removes duplicates before calling the application service.

Response body:

```json
[
  {
    "symbol": "AAPL",
    "timeframe": "1d",
    "signal": "BUY",
    "confidence": 0.87,
    "recommendedPrice": 174.32,
    "riskScore": 0.22,
    "source": "in-memory"
  }
]
```

| Situation | Response |
|---|---|
| At least one usable symbol | `200 OK` with the signals that exist |
| Missing or empty body | `400 Bad Request` |
| Only blank symbols | `400 Bad Request` |

## Signal response model

The complete model is defined in `src/QuasarQuant.Core/Models/SignalResponse.cs`. It currently includes:

- Identity and ownership: `id`, `userId`, `portfolioId`, `predictionId`
- Model metadata: `modelVersion`, `featureSetName`, `source`, `metadata`
- Timing and market data: `generatedAt`, `symbol`, `timeframe`, `targetTimestamp`
- Decision data: `signal`, `confidence`, `probabilities`, `positionSizePct`, `recommendedPrice`, `riskScore`
- Features: `featureVector`

## Interactive API documentation

In Development, Scalar and OpenAPI are registered by `QuasarQuant.API/Program.cs`. Start the API and open the generated API reference from the development server to inspect the current schema.

For the request flow behind these endpoints, see [Application Services](APPLICATION_SERVICES.md). For the running components, see [Backend Infrastructure](BACKEND_INFRASTRUCTURE.md).
