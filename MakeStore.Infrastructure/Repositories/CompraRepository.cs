using MakeStore.Application.Dto;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Infrastructure.Repositories
{
    public class CompraRepository : ICompraRespository
    {
        private readonly MakeStoreDbContext _context;

        public CompraRepository(MakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Compra>> Obter(Guid usuarioId)
        {
            var compras = await _context.Compras
                .Where(c => c.UsuarioId == usuarioId)
                .Include(p => p.Produtos)
                .ToListAsync();

            return compras;
        }

        public async Task<bool> Remover(int id)
        {
            var compra = await _context.Compras.FindAsync(id);

            if (compra == null)
            {
                return false;
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task SalvarCompraAsync(Compra compra)
        {
            if (compra == null)
            {
                throw new ArgumentNullException(nameof(compra), "Compra não pode ser nula");
            }
            var compraExistente = await _context.Compras.Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == compra.Id);

            if (compraExistente != null)
            {
                _context.Entry(compraExistente).CurrentValues.SetValues(compra);
                compraExistente.Produtos = compra.Produtos ?? new List<Produto>();
            }
            else
            {
                await _context.Compras.AddAsync(compra);
            }
            await _context.SaveChangesAsync();
        }
    }
}
