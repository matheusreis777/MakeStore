using MakeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Application.Dto
{
    public class CompraDto
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
