﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Domain.Entities;
public class CoresProdutos
{
    public int id { get; set; }
    public int carrinhoId { get; set; } 
    public string hex_value { get; set; }
    public string colour_name { get; set; }
}
