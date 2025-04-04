using MakeStore.Domain.Entities;

namespace MakeStore.Domain.Entities;

public class Produto
{
    public int id { get; set; }
    public string brand { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string price { get; set; } = string.Empty;
    public string price_sign { get; set; } = string.Empty;
    public string currency { get; set; } = string.Empty;
    public string image_link { get; set; } = string.Empty;
    public string product_link { get; set; } = string.Empty;
    public string website_link { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public double? rating { get; set; }  = 0.0;
    public string category { get; set; } = string.Empty;
    public string product_type { get; set; } = string.Empty;
    public List<string> tag_list { get; set; }
    public DateTime created_at { get; set; } = DateTime.Parse("2024-04-04");
    public DateTime updated_at { get; set; } = DateTime.Parse("2024-04-04");
    public string product_api_url { get; set; } = string.Empty;
    public string api_featured_image { get; set; } = string.Empty;
    public int quantidade { get; set; } = 1; 
    public string status { get; set; } = "pendente";

    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public List<CoresProdutos> product_colors { get; set; }
    public Produto()
    {
        tag_list = new List<string>();
        product_colors = new List<CoresProdutos>();
    }

    public void AlterarStatus(string statust)
    {
        status = statust;
    }

}

