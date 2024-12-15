using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Stocks.API.Slices.GetStocks;

public class GetStocksRequest : IRequest<GetStocksPaginatedResponse>
{ 
    public int Limit { get; set; } = 100; //not implemented
    public int Page { get; set; } = 1; //not implemented
}