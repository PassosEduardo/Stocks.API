using Stocks.API.Infrastructure.Repository.Brapi.Reponses;
using Stocks.API.Slices.GetStocks;
using System.Globalization;
using System.Text.Json;

namespace Stocks.API.Infrastructure.Repository.Brapi;

public class BrapiApiRequester : IStocksRepository
{
    private const string BASE_URL = "https://brapi.dev/api/";
    private const string TOKEN = "6Qp4qFdzgKMa467fQem8Cd";
    public async Task<StockPriceResponseDto>? GetStockAsync(string ticker)
    {
        using (var client = new HttpClient())
        {
            var request = await client.GetAsync(BASE_URL + $"quote/{ticker}?token={TOKEN}");

            if (!request.IsSuccessStatusCode)
                return null;
            
            var str = await request.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Root>(str).results.FirstOrDefault();
        }
    }

    public async Task<GetStocksPaginatedResponse> GetStocksPaginatedAsync(int page, int pageSize)
    {
        using (var client = new HttpClient())
        {
            var request = await client.GetAsync(
                BASE_URL + $"quote/list?limit={pageSize}&page={page}&type=stock&token={TOKEN}");

            var str = await request.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetStocksPaginatedResponse>(str);
        }
    }
}
