using System.ComponentModel.DataAnnotations.Schema;

namespace QuasarQuant.Core.Models;

public class TradeSignal
{
    public Guid id { get; set; } = Guid.NewGuid(); // Primary key
    
    [ForeignKey("User")]
    public Guid userId { get; set; }
    
    [ForeignKey("Portfolio")]
    public Guid portfolioId { get; set; }

    public string predictionId { get; set; } = string.Empty;
    public string modelVersion { get; set; } = string.Empty;
    public DateTime generatedAt { get; set; } = DateTime.UtcNow;
    public string symbol { get; set; } = string.Empty;
    public string timeframe { get; set; } = string.Empty;
    public DateTime targetTimestamp { get; set; }
    public string signal { get; set; } = string.Empty; // "BUY", "SELL", "HOLD"
    public double confidence { get; set; } // e.g., 0.87 (87%)
    public Dictionary<string, double> probabilities { get; set; } = new(); // e.g., {"BUY": 0.87, "SELL": 0.05, "HOLD": 0.08}
    public double positionSizePct { get; set; }
    public double recommendedPrice { get; set; }
    public string featureSetName { get; set; } = string.Empty;
    public Dictionary<string, double> featureVector { get; set; } = new(); // e.g., {"sma_10": 172.5, "rsi_14": 64.2, "macd": 0.8}
    public double riskScore { get; set; }
    public string source { get; set; } = string.Empty;
    public Dictionary<string, string> metadata { get; set; } = new(); // e.g., {"model_type": "RandomForest", "training_window": "2018-2026"}



}