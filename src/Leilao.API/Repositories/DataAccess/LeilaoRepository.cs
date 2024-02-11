namespace Leilao.API.Repositories.DataAccess;

public class LeilaoRepository
{
    private readonly LeilaoDbContext _dbContext;

    public LeilaoRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;

}
