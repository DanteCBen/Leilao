using Leilao.API.Contracts;
using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.Repositories.DataAccess;

public class LeilaoRepository : IAuctionRepository
{
    private readonly LeilaoDbContext _dbContext;

    public LeilaoRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var result = _dbContext
                .Auctions
                .Include(leilao => leilao.Items)
                .FirstOrDefault(IsAuctionOpened);

        return result;
    }
    private bool IsAuctionOpened(Auction auction)
    {
        var today = DateTime.Now;

        return today >= auction.Starts && today <= auction.Ends;
    }
}
