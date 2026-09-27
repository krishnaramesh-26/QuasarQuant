using Microsoft.AspNetCore.Mvc;
using QuasarQuant.Application.Signals;
using QuasarQuant.Core.Models;

namespace QuasarQuant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignalController : ControllerBase
{
    private readonly ISignalService signalService;

    public SignalController(ISignalService signalService)
    {
        this.signalService = signalService;
    }

    [HttpGet("{symbol}")]
    public async Task<ActionResult<TradeSignal>> GetSignal(
        string symbol,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(symbol))
        {
            return BadRequest("A symbol is required.");
        }

        var signal = await signalService.GetLatestAsync(
            symbol.Trim().ToUpperInvariant(),
            cancellationToken);

        return signal is null ? NotFound() : Ok(signal);
    }
    [HttpPost("batch")]
    public async Task<ActionResult<IEnumerable<TradeSignal>>> GetBatchSignals(
        [FromBody] List<string>? symbols,
        CancellationToken cancellationToken)
    {
        if (symbols is null || symbols.Count == 0)
        {
            return BadRequest("At least one symbol is required.");
        }

        var normalizedSymbols = symbols
            .Where(symbol => !string.IsNullOrWhiteSpace(symbol))
            .Select(symbol => symbol.Trim().ToUpperInvariant())
            .Distinct()
            .ToList();

        if (normalizedSymbols.Count == 0)
        {
            return BadRequest("At least one non-empty symbol is required.");
        }

        var signals = await signalService.GetLatestBatchAsync(
            normalizedSymbols,
            cancellationToken);

        return Ok(signals);
    }
}
