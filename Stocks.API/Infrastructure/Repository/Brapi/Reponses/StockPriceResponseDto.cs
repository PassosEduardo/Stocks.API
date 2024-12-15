using System.Text.Json.Serialization;

namespace Stocks.API.Infrastructure.Repository.Brapi.Reponses;
public class StockPriceResponseDto
{
    public string currency { get; set; }
    public string shortName { get; set; }
    public string longName { get; set; }
    public double regularMarketChange { get; set; }
    public double regularMarketChangePercent { get; set; }
    public DateTime regularMarketTime { get; set; }
    public double regularMarketPrice { get; set; }
    public double regularMarketDayHigh { get; set; }
    public string regularMarketDayRange { get; set; }
    public double regularMarketDayLow { get; set; }
    public int regularMarketVolume { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public double regularMarketOpen { get; set; }
    public string fiftyTwoWeekRange { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public string symbol { get; set; }
    public double priceEarnings { get; set; }
    public double earningsPerShare { get; set; }
    public string logourl { get; set; }
}

public class Root
{
    public List<StockPriceResponseDto> results { get; set; }
    public DateTime requestedAt { get; set; }
    public string took { get; set; }
}


