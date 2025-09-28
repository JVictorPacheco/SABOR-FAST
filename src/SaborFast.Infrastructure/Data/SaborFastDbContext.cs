using Microsoft.EntityFrameworkCore;

namespace SaborFast.Infrastructure.Data;

public class SaborFastDbContext : DbContext
{
    public SaborFastDbContext(DbContextOptions<SaborFastDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}