using Microsoft.AspNetCore.Mvc;
using QuasarQuant.Core.Models;

namespace QuasarQuant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignalController : ControllerBase
{
    [HttpGet("{symbol}")]
    public ActionResult<TradeSignal> GetSignal(string symbol)
    {
        
        if (string.IsNullOrWhiteSpace(symbol))
        {
            return BadRequest("A symbol is required.");
        }

        return NotFound($"No signal is available for symbol '{symbol}'.");
    }
}
