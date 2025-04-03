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
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Produto>>> GetProducts()
    {
        var products = await _produtoRepository.ObterProdutosAsync();
        return Ok(products);
    }

    [HttpPost("SalvarCarrinho")]
    public async Task<IActionResult> Post([FromBody] ProdutoDto item)
    {
        if (item == null)
        {
            return BadRequest("Produto inválido");
        }

        Produto produto = _mapper.Map<Produto>(item);
        await _produtoRepository.SalvarAsync(produto);
        return Ok(produto);
    }
}
