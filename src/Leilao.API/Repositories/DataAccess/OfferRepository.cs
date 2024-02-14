using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly LeilaoDbContext _dbContext;

    public OfferRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer newOffer)
    {
        _dbContext.Offers.Add(newOffer);

        _dbContext.SaveChanges();
    }
}
