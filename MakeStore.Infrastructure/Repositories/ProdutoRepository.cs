﻿using MakeStore.Application.DTOs;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MakeStore.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly MakeStoreDbContext _context;

        public ProdutoRepository(HttpClient httpClient, IConfiguration configuration, MakeStoreDbContext context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _context = context;
        }

        public async Task<List<Produto>> ObterProdutosAsync()
        {
            var BaseUrl = _configuration["MakeApi:Url"];
            var response = await _httpClient.GetAsync(BaseUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Erro ao buscar produtos: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Produto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task SalvarAsync(Produto objeto)
        {
            if (objeto == null)
            {
                throw new ArgumentNullException(nameof(objeto), "Produto não pode ser nulo");
            }

            var produtoExistente = await _context.Produtos
                .Include(p => p.product_colors) 
                .FirstOrDefaultAsync(p => p.id == objeto.id);

            if (produtoExistente != null)
            {
                _context.Entry(produtoExistente).CurrentValues.SetValues(objeto);

                produtoExistente.product_colors = objeto.product_colors ?? new List<CoresProdutos>();
                produtoExistente.tag_list = objeto.tag_list ?? new List<string>();
            }
            else
            {
                objeto.product_colors ??= new List<CoresProdutos>();
                objeto.tag_list ??= new List<string>();

                _context.Produtos.Add(objeto);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> ObterCarrinhoAsync(Guid usuarioId)
        {
            return await _context.Produtos
                .Include(p => p.product_colors)
                .Where(p => p.UsuarioId == usuarioId && p.status == "Pendente")
                .ToListAsync();
        }

        public async Task<bool> RemoverItemCarrinho(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return false;
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AlterarStatusCarrinho(List<int> ids, string status)
        {
            var produtos = await _context.Produtos.Where(p => ids.Contains(p.id)).ToListAsync();

            if (!produtos.Any())
            {
                return false;
            }

            foreach (var produto in produtos)
            {
                produto.status = status;
            }

            _context.Produtos.UpdateRange(produtos);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
