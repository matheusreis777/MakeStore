using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using MakeStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MakeStore.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MakeStoreDbContext _context;

        public UsuarioRepository(MakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
