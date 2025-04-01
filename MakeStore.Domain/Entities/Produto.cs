using MakeStore.Domain.Entities;

namespace MakeStore.Domain.Entities;

public class Produto
{
    public int id { get; set; }
    public string brand { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public string price_sign { get; set; }
    public string currency { get; set; }
    public string image_link { get; set; }
    public string product_link { get; set; }
    public string website_link { get; set; }
    public string description { get; set; }
    public decimal? rating { get; set; } // Pode ser nulo
    public string category { get; set; }
    public string product_type { get; set; }
    public List<string> tag_list { get; set; } // Supondo que seja uma lista de strings
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string product_api_url { get; set; }
    public string api_featured_image { get; set; }

    // Relacionamento com CoresProdutos
    public List<CoresProdutos> cores { get; set; } // Lista de cores associadas ao produto
}

