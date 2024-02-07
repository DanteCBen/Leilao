using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;
namespace Leilao.API.Repositories;

public class LeilaoDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Dante\\Downloads\\leilaoDbNLW.db");
    }
}
