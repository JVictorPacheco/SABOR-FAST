//using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SaborFast.Core.Entities;


namespace SaborFast.Infrastructure.Data;

public class SaborFastDbContext : DbContext
{
    public SaborFastDbContext(DbContextOptions<SaborFastDbContext> options) : base(options)
    {
    }

    public DbSet<Restaurante> Restaurantes { get; set; } = null!;
    public DbSet<CardapioItem> CardapioItems { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}