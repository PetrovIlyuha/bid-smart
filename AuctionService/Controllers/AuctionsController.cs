using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route(Endpoints.AuctionsEndpoint)]
public class AuctionsController : ControllerBase
{
    private readonly AuctionDbContext _auctionsDbContext;
    private readonly IMapper _mapper;

    public AuctionsController(AuctionDbContext context, IMapper mapper)
    {
        _auctionsDbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions(string date)
    {
        var query = _auctionsDbContext.Auctions.OrderBy(x => x.Item.Manufacturer).AsQueryable();
        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<AuctionDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id)
    {
        var auction = await _auctionsDbContext.Auctions.Include(a => a.Item).FirstOrDefaultAsync(a => a.Id == id);

        if (auction == null)
        {
            return NotFound();
        }
        return _mapper.Map<AuctionDto>(auction);
    }

    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto createAuctionDto)
    {
        var auction = _mapper.Map<Auction>(createAuctionDto);
        // TODO: add current user as seller for auction item
        var auctionExists = await _auctionsDbContext.Auctions.Include(a => a.Item).FirstOrDefaultAsync(x => x.Item.Name == createAuctionDto.Name);
        if (auctionExists != null)
        {
            return BadRequest("Auction with this Item already exists");
        }
        auction.Seller = "Test Seller";
        _auctionsDbContext.Auctions.Add(auction);
        var result = await _auctionsDbContext.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Could not create auction");
        return CreatedAtAction(nameof(GetAuctionById), new { id = auction.Id }, _mapper.Map<AuctionDto>(auction));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDto updateAuctionDto)
    {
        var auction = await _auctionsDbContext.Auctions.Include(a => a.Item).FirstOrDefaultAsync(a => a.Id == id);
        if (auction == null) return NotFound();
        // TODO: check if user is matching the seller
        auction.Item.Manufacturer = updateAuctionDto.Manufacturer ?? auction.Item.Manufacturer;
        auction.Item.ProductionYear = updateAuctionDto.ProductionYear ?? auction.Item.ProductionYear;
        auction.Item.Name = updateAuctionDto.Name ?? auction.Item.Name;
        auction.Item.Category = updateAuctionDto.Category ?? auction.Item.Category;
        auction.Item.Description = updateAuctionDto.Description ?? auction.Item.Description;
        var result = await _auctionsDbContext.SaveChangesAsync() > 0;
        if (result) return Ok();
        return BadRequest("Could not update an auction");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuction(Guid id)
    {
        var auction = await _auctionsDbContext.Auctions.FindAsync(id);
        if (auction == null) return NotFound();
        // TODO: check user permissions
        _auctionsDbContext.Auctions.Remove(auction);
        var result = await _auctionsDbContext.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Could not delete an auction");
        return Ok();
    }
}