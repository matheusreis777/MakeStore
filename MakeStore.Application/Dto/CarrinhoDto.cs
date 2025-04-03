using MakeStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Application.Dto
{
    public  class CarrinhoDto
    {
        public int id { get; set; }
        public string? brand { get; set; }
        public string? name { get; set; }
        public string? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? api_featured_image { get; set; }
        public Guid usuarioId { get; set; }

        public UsuarioDto? Usuario { get; set; }
        public CoresProdutosDto? product_colors { get; set; }

        public CarrinhoDto() { }
    }
}
