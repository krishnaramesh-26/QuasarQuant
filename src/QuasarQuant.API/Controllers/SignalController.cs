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
}
