using QuasarQuant.Core.Models;
using QuasarQuant.Application.Signals;
using Microsoft.EntityFrameworkCore;
namespace QuasarQuant.Repository.Signals;

public class SignalRepository : ISignalRepository
{
    private readonly AppDbContext dbContext;

    public SignalRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<TradeSignal?> GetLatestAsync(string symbol, CancellationToken cancellationToken)
    {
        return await dbContext.TradeSignals
            .Where(signal => signal.symbol == symbol)
            .OrderByDescending(signal => signal.generatedAt)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<IReadOnlyList<TradeSignal>> GetLatestBatchAsync(IEnumerable<string> symbols, CancellationToken cancellationToken)
    {
        foreach (string symbol in symbols)
        {
            var latestSignal = dbContext.TradeSignals
                .Where(signal => signal.symbol == symbol)
                .OrderByDescending(signal => signal.generatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (latestSignal != null)
            {
                return Task.FromResult<IReadOnlyList<TradeSignal>>(new List<TradeSignal> { latestSignal.Result });
            }
        }
        return Task.FromResult<IReadOnlyList<TradeSignal>>(new List<TradeSignal>());
    }
}

