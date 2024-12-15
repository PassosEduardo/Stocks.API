using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Stocks.API.Infrastructure.Repository.Brapi.Reponses;

namespace Stocks.API.Slices.GetStockPrice;

public static class GetStockPriceMapper
{
    public static GetStockPriceResponse MapToGetStockPriceResponse(this StockPriceResponseDto responseDto)
    {
        if (responseDto is null)
            return default;

        return new GetStockPriceResponse()
        {
            CompanyName = responseDto.longName,
            Currency = responseDto.currency,
            DayHigh = decimal.Parse(responseDto.regularMarketDayHigh.ToString()),
            DayLow = decimal.Parse(responseDto.regularMarketDayLow.ToString()),
            DayOpeningPrice = decimal.Parse(responseDto.regularMarketOpen.ToString()),
            Price = decimal.Parse(responseDto.regularMarketPrice.ToString()),
            Ticker = responseDto.symbol

        };
    }
}
