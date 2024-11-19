using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitMongoDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings
                .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Item>()
            .Key(i => i.Manufacturer, KeyType.Text)
            .Key(i => i.Name, KeyType.Text)
            .Key(i => i.Category, KeyType.Text)
            .CreateAsync();

        var countDocuments = await DB.CountAsync<Item>();
        using var scope = app.Services.CreateScope();
        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();
        var items = await httpClient.GetItemsForSearchDb();
        Console.WriteLine("found (" + items.Count + ") new records in auction service database to be migrated to search service mongo database");
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            await DB.SaveAsync(items);
        }
        // var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // if (countDocuments == 0)
        // {
        //     Console.WriteLine("No data in search mongodb database. Attempting to seed...");
        //     var itemData = await File.ReadAllTextAsync("Data/auctions.json");
        //
        //     var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);
        //     await DB.SaveAsync(items);
        // }
    }
}