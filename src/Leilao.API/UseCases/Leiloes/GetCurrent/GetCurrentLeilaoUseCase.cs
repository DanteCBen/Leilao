using Leilao.API.Entities;
using Leilao.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.UseCases.Leiloes.GetCurrent;

public class GetCurrentLeilaoUseCase
{
    public Auction? Execute()
    {
        var repository = new LeilaoDbContext();

        return repository.Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(IsAuctionOpened);
    }

    private bool IsAuctionOpened(Auction auction)
    {
        var today = DateTime.Now;

        return today >= auction.Starts && today <= auction.Ends;
    }
}
