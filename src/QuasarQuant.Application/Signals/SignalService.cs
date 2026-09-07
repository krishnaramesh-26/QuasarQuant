using QuasarQuant.Core.Models;
namespace QuasarQuant.Application.Signals;

public class SignalService : ISignalService
{
    private readonly ISignalRepository signalRepository;

    public SignalService(ISignalRepository signalRepository)
    {
        this.signalRepository = signalRepository;
    }

    public Task<TradeSignal?> GetLatestAsync(
        string symbol,
        CancellationToken cancellationToken)
    {
        return signalRepository.GetLatestAsync(symbol, cancellationToken);
    }

    public Task<IReadOnlyList<TradeSignal>> GetLatestBatchAsync(
        IEnumerable<string> symbols,
        CancellationToken cancellationToken)
    {
        return signalRepository.GetLatestBatchAsync(symbols, cancellationToken);
    }

}