using MakeStore.Domain.Entities;
using System.Threading.Tasks;

namespace MakeStore.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Usuario?> ObterPorEmailAsync(string email);
    }
}
