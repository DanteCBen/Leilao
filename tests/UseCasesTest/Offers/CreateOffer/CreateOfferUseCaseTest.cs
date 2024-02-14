using Bogus;
using FluentAssertions;
using Leilao.API.Communication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.UseCases.Offers.CreateOffer;
using Moq;
using Xunit;

namespace UseCasesTest.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // ARRANGE
        var fakeRequest = new Faker<RequestCreateOfferJson>()
           .RuleFor(request => request.Price, faker => faker.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);

        // ACT - realiza a operação que deve ser feit
        var act = () => useCase.Execute(itemId, fakeRequest);

        // ASSERT - faz a verificação de teste
        act.Should().NotThrow();
    }
}
