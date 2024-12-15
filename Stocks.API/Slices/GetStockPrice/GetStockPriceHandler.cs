using MediatR;
using Stocks.API.Infrastructure.Redis;
using Stocks.API.Infrastructure.Repository;

namespace Stocks.API.Slices.GetStockPrice;

public class GetStockPriceHandler : IRequestHandler<GetStockPriceRequest, GetStockPriceResponse>
{
    private readonly IStocksRepository _stocksRepository;
    private readonly IRedisHandler _redisHandler;

    public GetStockPriceHandler(IStocksRepository stocksRepository, IRedisHandler redisHandler)
    {
        _stocksRepository = stocksRepository;
        _redisHandler = redisHandler;
    }

    public async Task<GetStockPriceResponse> Handle(GetStockPriceRequest request, CancellationToken cancellationToken)
    {
        var cacheResult = await _redisHandler.GetValueByKeyAsync<GetStockPriceResponse>(request.StockTicker);

        if (cacheResult is not null)
            return cacheResult;

        var resultDto = await _stocksRepository.GetStockAsync(request.StockTicker);

        if (resultDto is null)
            return null;

        var result = resultDto.MapToGetStockPriceResponse();

        _redisHandler.SaveAsync<GetStockPriceResponse>(request.StockTicker, result, RedisSaveTimeOptions.FIVE_MINUTES);

        return result;
    }
}
