using MongoDB.Entities;

namespace SearchService.Models;

public class Item : Entity
{
    public int ReservedPrice { get; set; }
    public string Seller { get; set; }
    public string Winner { get; set; }
    public int SoldAmount { get; set; }
    public int CurrentHighBid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; }
    // auction item fields
    public string Manufacturer { get; set; }
    public int ProductionYear { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
}