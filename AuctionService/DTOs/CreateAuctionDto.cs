namespace AuctionService.DTOs;

public class CreateAuctionDto
{
    public required string Manufacturer { get; set; }
    public required int ProductionYear { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string ImageUrl { get; set; }
    public required int ReservedPrice { get; set; }
    public required DateTime AuctionEnd { get; set; }
}