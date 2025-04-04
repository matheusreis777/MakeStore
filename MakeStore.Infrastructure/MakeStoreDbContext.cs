using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using MakeStore.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MakeStore.Infrastructure;

public class MakeStoreDbContext : DbContext, IUnitOfWork
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CoresProdutos> CoresProdutos { get; set; }
    public DbSet<Compra> Compras { get; set; }

    public MakeStoreDbContext(DbContextOptions<MakeStoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MakeStoreDbContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        try
        {
            return await SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
