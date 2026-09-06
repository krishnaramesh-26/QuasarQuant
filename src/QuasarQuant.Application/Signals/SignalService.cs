using QuasarQuant.Core.Models;

namespace QuasarQuant.Application.Signals;

public class SignalService : ISignalService
{
    public Task<TradeSignal?> GetLatestAsync(
        string symbol,
        CancellationToken cancellationToken)
    {
        // Temporary placeholder until a repository exists.
        return Task.FromResult<TradeSignal?>(null);
    }
    public Task<IReadOnlyList<TradeSignal>> GetLatestBatchAsync(
        IEnumerable<string> symbols,
        CancellationToken cancellationToken)
    {
        // Temporary placeholder until a repository exists.
        return Task.FromResult<IReadOnlyList<TradeSignal>>(new List<TradeSignal>());
    }

}