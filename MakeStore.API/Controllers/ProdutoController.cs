using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeStore.WebAPI.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IRepository<Produto> _repository;

    public ProdutoController(IRepository<Produto> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return Ok(await _repository.GetAllAsync());
    }
}
