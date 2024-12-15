using System.Text.Json.Serialization;

namespace Stocks.API.Slices.GetStocks;

public class GetStocksPaginatedResponse
{
    public List<Stock> stocks { get; set; }
    public int currentPage { get; set; }
    public int totalPages { get; set; }
    public int itemsPerPage { get; set; }
    public int totalCount { get; set; }
    public bool hasNextPage { get; set; }
}

public class Stock
{
    public string stock { get; set; }
    public string name { get; set; }
    public double close { get; set; }
    [JsonIgnore]
    public double change { get; set; }
    [JsonIgnore]
    public int volume { get; set; }
    [JsonIgnore]
    public double market_cap { get; set; }
    [JsonIgnore]
    public string logo { get; set; }
    [JsonIgnore]
    public string sector { get; set; }
    public string type { get; set; }
}
