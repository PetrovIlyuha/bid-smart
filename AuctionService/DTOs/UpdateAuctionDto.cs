namespace AuctionService.DTOs;

public class UpdateAuctionDto
{
    public string Manufacturer { get; set; }
    public int? ProductionYear { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}