using MakeStore.Domain.Entities; 
using MakeStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakeStore.Infrastructure.Repositories;

namespace MakeStore.API.Controllers 
{
    [ApiController]
    [Route("api/coresProduto")]
    public class CoresProdutoController : ControllerBase
    {
        private readonly IRepository<CoresProdutos> _repository;

        public CoresProdutoController(IRepository<CoresProdutos> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoresProdutos>>> GetProdutos()
        {
            return Ok(await _repository.GetAllAsync());
        }
    }
}
