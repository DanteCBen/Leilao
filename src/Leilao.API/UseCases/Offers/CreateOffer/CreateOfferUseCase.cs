using Leilao.API.Communication.Requests;
using Leilao.API.Entities;
using Leilao.API.Repositories;
using Leilao.API.Services;

namespace Leilao.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser logged) => _loggedUser = logged;

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new LeilaoDbContext();

        var user = _loggedUser.User();

        var newOffer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Offers.Add(newOffer);

        repository.SaveChanges();

        return newOffer.Id;
    }
}
