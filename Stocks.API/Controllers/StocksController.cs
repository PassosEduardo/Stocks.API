using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stocks.API.Slices.GetStockPrice;
using Stocks.API.Slices.GetStocks;
using StackExchange.Redis;

namespace Stocks.API.Controllers;

[ApiController]
[Route("v1/stocks")]
public class StocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public StocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns the details of a stock
    /// </summary>
    /// <param name="request"></param>
    [HttpGet("{stockTicker}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetStockPriceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetStockPriceResponse>> GetStockPriceAsync([FromRoute] GetStockPriceRequest request)
    {
        var result = await _mediator.Send(request);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Returns a list of stocks
    /// </summary>
    /// <param name="request"></param>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<GetStockPriceResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStocksAsync([FromRoute] GetStocksRequest request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}
