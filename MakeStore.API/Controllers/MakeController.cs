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
public class MakeController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public MakeController(IProdutoRepository produtoRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Produto>>> GetProducts()
    {
        var products = await _produtoRepository.ObterProdutosAsync();
        return Ok(products);
    }
}
