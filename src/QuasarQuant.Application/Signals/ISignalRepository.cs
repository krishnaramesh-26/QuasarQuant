using QuasarQuant.Core.Models;

namespace QuasarQuant.Application.Signals;

public interface ISignalRepository
{
    Task<TradeSignal?> GetLatestAsync(
        string symbol,
        CancellationToken cancellationToken);
}