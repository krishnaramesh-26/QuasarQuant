using QuasarQuant.Core.Models;

namespace QuasarQuant.Application.Signals;

public interface ISignalService
{
    Task<TradeSignal?> GetLatestAsync(
        string symbol,
        CancellationToken cancellationToken);

        Task<IReadOnlyList<TradeSignal>> GetLatestBatchAsync(
        IEnumerable<string> symbols,
        CancellationToken cancellationToken);   
}