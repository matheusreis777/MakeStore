using MakeStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeStore.Infrastructure.Mappings;

public class CoresProdutosMap : IEntityTypeConfiguration<CoresProdutos>
{
    public void Configure(EntityTypeBuilder<CoresProdutos> builder)
    {
        builder.ToTable("ProdutoCor");

        builder.HasKey(c => c.id);

        builder.Property(c => c.id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.prodtuoId)
            .IsRequired();

        builder.Property(c => c.hex_value)
            .HasMaxLength(7) 
            .IsRequired();

        builder.Property(c => c.colour_name)
            .HasMaxLength(50);

        builder.HasOne<Produto>()
            .WithMany(p => p.product_colors)
            .HasForeignKey(c => c.prodtuoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
