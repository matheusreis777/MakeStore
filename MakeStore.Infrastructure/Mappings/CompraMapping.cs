using MakeStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Infrastructure.Mappings
{
    public  class CompraMapping : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.DataCompra)
                .IsRequired();
            builder.Property(c => c.ValorTotal)
                .IsRequired();

            builder.Property(c => c.FormaPagamento)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(c => c.Usuario) 
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
