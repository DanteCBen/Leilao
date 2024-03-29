﻿using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;
namespace Leilao.API.Repositories;

public class LeilaoDbContext : DbContext
{
    public LeilaoDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Dante\\Downloads\\leilaoDbNLW.db");
    }
}
