using MakeStore.Application.DTOs;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MakeStore.Infrastructure.Repositories
{
    public  class ProdutoRepository : IProdutoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProdutoRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
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
    }
}
