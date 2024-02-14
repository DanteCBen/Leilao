using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.UseCases.Leiloes.GetCurrent;

public class GetCurrentLeilaoUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentLeilaoUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute() => _repository.GetCurrent();
}
