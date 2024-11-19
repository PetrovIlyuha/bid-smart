using System.Globalization;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class AuctionServiceHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AuctionServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Item>> GetItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.Descending(i => i.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString(CultureInfo.InvariantCulture)).ExecuteFirstAsync();
        Console.WriteLine("Last update in mongo: " + lastUpdated);
        return await _httpClient.GetFromJsonAsync<List<Item>>(_configuration["AuctionServiceUrl"] +
                                                              $"/api/auctions?date={lastUpdated}");
    }
}