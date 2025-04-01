using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakeStore.Infrastructure;

public class MakeStoreDbContext : DbContext, IUnitOfWork
{
    public MakeStoreDbContext(DbContextOptions<MakeStoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MakeStoreDbContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}
