using MediatR;
using Stocks.API.Infrastructure.Repository;

namespace Stocks.API.Slices.GetStocks;

public class GetStocksHandler : IRequestHandler<GetStocksRequest, GetStocksPaginatedResponse>
{
    private readonly IStocksRepository _stocksRepository;

    public GetStocksHandler(IStocksRepository stocksRepository)
    {
        _stocksRepository = stocksRepository;
    }
    public async Task<GetStocksPaginatedResponse> Handle(GetStocksRequest request, CancellationToken cancellationToken)
    {
        return await _stocksRepository.GetStocksPaginatedAsync(request.Page, request.Limit);
    }
}
