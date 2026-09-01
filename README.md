## Info

### Project Summary in [Project Summary](docs/PROJECT_SUMMARY.md)


## Example Predicition from Fast API service
 ```json
 {
  "prediction_id": "a7b9c3d4-1f2e-4c6b-9d3f-0a1b2c3d4e5f",
  "model_version": "random_forest_v1",
  "generated_at": "2026-09-01T12:34:56Z",
  "symbol": "AAPL",
  "timeframe": "1d",
  "target_timestamp": "2026-09-01T00:00:00Z",
  "signal": "BUY",
  "confidence": 0.87,
  "probabilities": { "BUY": 0.87, "SELL": 0.05, "HOLD": 0.08 },
  "position_size_pct": 2.5,
  "recommended_price": 174.32,
  "feature_set_name": "v1_basic_tech",
  "feature_vector": { "sma_10": 172.5, "rsi_14": 64.2, "macd": 0.8 },
  "risk_score": 0.22,
  "source": "live",
  "metadata": { "model_type": "RandomForest", "training_window": "2018-2026" }
}
```

Will be sent as batch predictions

```json
{
[
  { /* prediction 1 */ },
  { /* prediction 2 */ },
  { /* prediction 3 */ }
]
}
```