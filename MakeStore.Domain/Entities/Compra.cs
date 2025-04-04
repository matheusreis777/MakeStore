using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; } = DateTime.Parse("2024-04-04");
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public Compra()
        {
            Produtos = new List<Produto>();
        }
    }
}
