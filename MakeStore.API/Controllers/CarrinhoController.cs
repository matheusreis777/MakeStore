using AutoMapper;
using MakeStore.Application.Dto;
using MakeStore.Application.DTOs;
using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MakeStore.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarrinhoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public CarrinhoController(IProdutoRepository produtoRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("SalvarCarrinho")]
    public async Task<IActionResult> Post([FromBody] ProdutoDto item)
    {
        if (item == null)
        {
            return BadRequest("Produto inválido");
        }

        var usuario = await _usuarioRepository.ObterPorEmailAsync(item.email);
        Guid usuarioId = usuario.Id;
        item.UsuarioId = usuarioId;

        Produto produto = _mapper.Map<Produto>(item);
        await _produtoRepository.SalvarAsync(produto);
        return Ok();
    }

    [HttpGet("ObterCarrinho/{email}")]
    public async Task<ActionResult<List<CarrinhoDto>>> ObterCarrinho(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email inválido");
        }

        var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
        Guid usuarioId = usuario.Id;

        var products = await _produtoRepository.ObterCarrinhoAsync(usuarioId);
        var produtosDto = _mapper.Map<List<ProdutoDto>>(products);

        var carrinho = new List<CarrinhoDto>();

        foreach (var productDto in produtosDto)
        {
            if (productDto.UsuarioId == usuarioId)
            {
                var carrinhoItem = new CarrinhoDto
                {
                    id = productDto.id,
                    name = productDto.name,
                    price = productDto.price,
                    description = productDto.description,
                    category = productDto.category,
                    usuarioId = productDto.UsuarioId,
                    product_colors = productDto.product_colors[0],
                    api_featured_image = productDto.api_featured_image,
                    quantidade = productDto.quantidade,
                    Usuario = productDto.Usuario,
                };
                carrinho.Add(carrinhoItem);
            }
        }
        return Ok(carrinho);
    }

    [HttpDelete("RemoverItemCarrinho/{id}")]
    public async Task<bool> RemoverItemCarrinho(int id)
    {      
        bool removido = await _produtoRepository.RemoverItemCarrinho(id);
        return removido;
    }

}
