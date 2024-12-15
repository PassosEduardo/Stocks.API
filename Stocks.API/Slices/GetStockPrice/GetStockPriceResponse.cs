namespace Stocks.API.Slices.GetStockPrice;

public class GetStockPriceResponse
{
    public string CompanyName { get; set; }
    public string Ticker {  get; set; }
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public decimal DayHigh { get; set; }
    public decimal DayLow { get; set; }
    public decimal DayOpeningPrice { get; set; }
}

