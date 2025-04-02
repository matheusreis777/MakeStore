using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeStore.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Produto>>> GetProducts()
    {
        var products = await _produtoRepository.ObterProdutosAsync();
        return Ok(products);
    }
}
