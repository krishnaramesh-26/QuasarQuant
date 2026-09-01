namespace QuasarQuant.Core.Models;

public class TradeSignal
{
    public string Symbol { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; // "BUY", "SELL", "HOLD"
    public double Confidence { get; set; }             // e.g., 0.85 (85%)
    public string Rationale { get; set; } = string.Empty; // e.g., "XGBoost bullish divergence"
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}