using MakeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Domain.Interfaces
{
    public interface ICompraRespository
    {
        Task<List<Compra>> Obter(Guid usuarioId);
        Task SalvarCompraAsync(Compra compra);
        Task<bool> Remover(int id);
    }
}
