using QuasarQuant.Application.Signals;
using QuasarQuant.Core.Models;

namespace QuasarQuant.Infrastructure.Signals;

public class InMemorySignalRepository : ISignalRepository
{
    public Task<TradeSignal?> GetLatestAsync(
        string symbol,
        CancellationToken cancellationToken)
    {

        // Temporary in-memory implementation for demonstration purposes.
        TradeSignal? signal = symbol switch
        {
            "AAPL" => new TradeSignal
            {
                symbol = "AAPL",
                timeframe = "1d",
                signal = "BUY",
                confidence = 0.87,
                probabilities = new Dictionary<string, double>
                {
                    ["BUY"] = 0.87,
                    ["SELL"] = 0.05,
                    ["HOLD"] = 0.08
                },
                recommendedPrice = 174.32,
                riskScore = 0.22,
                source = "in-memory"
            },
            "MSFT" => new TradeSignal
            {
                symbol = "MSFT",
                timeframe = "1d",
                signal = "HOLD",
                confidence = 0.74,
                probabilities = new Dictionary<string, double>
                {
                    ["BUY"] = 0.16,
                    ["SELL"] = 0.10,
                    ["HOLD"] = 0.74
                },
                recommendedPrice = 420.15,
                riskScore = 0.18,
                source = "in-memory"
            },
            _ => null
        };

        return Task.FromResult(signal);
    }


    public Task<IReadOnlyList<TradeSignal>> GetLatestBatchAsync(
        IEnumerable<string> symbols,
        CancellationToken cancellationToken)
    {
        // Temporary in-memory implementation for demonstration purposes.
        var signals = symbols.Select(symbol => GetLatestAsync(symbol, cancellationToken).Result)
                             .Where(signal => signal != null)
                             .ToList();

        return Task.FromResult<IReadOnlyList<TradeSignal>>(signals);
    }
}