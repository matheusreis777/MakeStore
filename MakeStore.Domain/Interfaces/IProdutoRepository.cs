using MakeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MakeStore.Domain.Interfaces
{
    public interface IProdutoRepository 
    {
        Task<List<Produto>> ObterProdutosAsync();
        Task SalvarAsync(Produto produto);
        Task<List<Produto>> ObterCarrinhoAsync(Guid usuarioId);
        Task<bool> RemoverItemCarrinho(int id);
        Task<bool> AlterarStatusCarrinho(List<int> id, string statust);
    }
}
