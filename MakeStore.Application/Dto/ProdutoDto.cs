using MakeStore.Application.Dto;

namespace MakeStore.Application.DTOs
{
    public class ProdutoDto
    {
        public int id { get; set; }
        public string brand { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string price { get; set; } = String.Empty;
        public string price_sign { get; set; } = String.Empty;
        public string currency { get; set; } = String.Empty;
        public string image_link { get; set; } = String.Empty;
        public string product_link { get; set; } = String.Empty;
        public string website_link { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
        public double? rating { get; set; }
        public string category { get; set; } = String.Empty;
        public string product_type { get; set; } = String.Empty;
        public List<string> tag_list { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int quantidade { get; set; }
        public string product_api_url { get; set; } = String.Empty;
        public string api_featured_image { get; set; } = String.Empty;
        public string email { get; set; }
        public string status { get; set; }

        public Guid UsuarioId { get; set; }
        public UsuarioDto? Usuario { get; set; }
        public List<CoresProdutosDto> product_colors { get; set; }
    }
}
