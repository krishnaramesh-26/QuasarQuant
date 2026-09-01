using Microsoft.AspNetCore.Mvc;

namespace QusasarQuant.API.Controllers;
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {

        [HttpGet("{symbol}")]
        public ActionResult<TradeSignal> GetSignal(string symbol)
        {
            
        }
    }
}
