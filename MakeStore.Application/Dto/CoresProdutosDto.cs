using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Application.Dto
{
    public  class CoresProdutosDto
    {
        public int id { get; set; }
        public int carrinhoId { get; set; }
        public string hex_value { get; set; }
        public string colour_name { get; set; }
    }
}
