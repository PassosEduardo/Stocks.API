using Stocks.API.Infrastructure.Repository.Brapi.Reponses;
using Stocks.API.Slices.GetStockPrice;
using Stocks.API.Slices.GetStocks;

namespace Stocks.API.Infrastructure.Repository;

public interface IStocksRepository
{
    Task<StockPriceResponseDto> GetStockAsync(string ticker);
    Task<GetStocksPaginatedResponse> GetStocksPaginatedAsync(int page, int pageSize);
}
