using FluentAssertions;
using Leilao.API.Contracts;
using Leilao.API.UseCases.Leiloes.GetCurrent;
using Leilao.API.Entities;
using Moq;
using Xunit;
using Bogus;
using Leilao.API.Enums;

namespace UseCasesTest.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        // ARRANGE
        var fakeAuction = new Faker<Auction>()
            .RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 10))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
            .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
            .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>
            {
                new Item
                {
                    Id = faker.Random.Number(1, 600),
                    Name = faker.Commerce.ProductName(),
                    Brand = faker.Commerce.Department(),
                    BasePrice = faker.Random.Decimal(50, 1000),
                    Condition = faker.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(fakeAuction);

        var useCase = new GetCurrentLeilaoUseCase(mock.Object);

        // ACT - realiza a operação que deve ser feit
        var auction = useCase.Execute();

        // ASSERT - faz a verificação de teste
        auction.Should().NotBeNull();
        auction.Id.Should().Be(fakeAuction.Id);
        auction.Name.Should().Be(fakeAuction.Name);

    }
}
