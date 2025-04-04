using MakeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Application.Dto
{
    public  class CompraReduzidaDto
    {
        public string Email { get; set; }
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }
        public List<int> ProdutoId { get; set; }
    }
}
