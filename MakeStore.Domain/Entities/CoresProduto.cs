using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Domain.Entities;
public class CoresProdutos
{
    public int id { get; set; }
    public int prodtuoId { get; set; } 
    public string hex_value { get; set; } = string.Empty;
    public string colour_name { get; set; } = string.Empty;
}
