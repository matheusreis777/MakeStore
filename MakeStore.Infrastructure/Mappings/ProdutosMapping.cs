using MakeStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MakeStore.Infrastructure.Mappings
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.id);

            builder.Property(p => p.id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.price)
                .HasMaxLength(10);

            builder.Property(p => p.price_sign)
                .HasMaxLength(10);

            builder.Property(p => p.currency)
                .HasMaxLength(10);

            builder.Property(p => p.image_link)
                .HasMaxLength(500);

            builder.Property(p => p.product_link)
                .HasMaxLength(500);

            builder.Property(p => p.website_link)
                .HasMaxLength(500);

            builder.Property(p => p.description)
                .HasMaxLength(1000);

            builder.Property(p => p.rating)
                .HasColumnType("decimal(5,2)");

            builder.Property(p => p.category)
                .HasMaxLength(100);

            builder.Property(p => p.product_type)
                .HasMaxLength(100);

            builder.Property(p => p.created_at)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.updated_at)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.product_api_url)
                .HasMaxLength(500);

            builder.Property(p => p.api_featured_image)
                .HasMaxLength(500);

            builder.Ignore(p => p.tag_list);

            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.product_colors)
                .WithOne()
                .HasForeignKey(c => c.produtoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
