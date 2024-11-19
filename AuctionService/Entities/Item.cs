using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Items")]
public class Item
{
    public Guid Id { get; init; }
    
    [MaxLength(200)]
    public string Manufacturer { get; set; }
    
    public int ProductionYear { get; set; }
    
    [MaxLength(255)]
    public string Name { get; set; }
    
    [MaxLength(700)]
    public string Description { get; set; }
    
    [MaxLength(140)]
    public string Category { get; set; }
    
    [MaxLength(300)]
    public string ImageUrl { get; set; }

    // relation to auction for ef
    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }
}