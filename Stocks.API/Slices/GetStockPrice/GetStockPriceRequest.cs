using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Stocks.API.Slices.GetStockPrice;

public class GetStockPriceRequest : IRequest<GetStockPriceResponse>
{
    /// <example>VALE3</example>
    /// <example>PETR4</example>
    /// <example>BBAS3</example>
    [FromRoute(Name = "stockTicker")]
    [Required(AllowEmptyStrings = false)]
    public string StockTicker { get; set; }
}
