using AutoMapper;
using MakeStore.Application.Dto;
using MakeStore.Application.DTOs;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using MakeStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MakeStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CompraController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICompraRespository _compraRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CompraController(IMapper mapper, ICompraRespository compraRepository, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _compraRepository = compraRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet("ObterCompras/{email}")]
        public async Task<ActionResult<List<CompraDto>>> ObterCompras(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            Guid usuarioId = usuario.Id;
            var compra = await _compraRepository.Obter(usuarioId);

            var retorno = _mapper.Map<List<CompraDto>>(compra);
            return Ok(retorno);
        }

            [HttpPost("SalvarCompra")]
        public async Task<IActionResult> Post([FromBody] CompraReduzidaDto dto)
        {
            Compra compra = new();

            var usuario = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
            Guid usuarioId = usuario.Id;
            compra.UsuarioId = usuarioId;
            compra.DataCompra = DateTime.Now;
            compra.Usuario = usuario;
            compra.ValorTotal = dto.Valor;
            compra.FormaPagamento = dto.FormaPagamento;

            await _compraRepository.SalvarCompraAsync(compra);
            await _produtoRepository.AlterarStatusCarrinho(dto.ProdutoId, "Pago");

            return Ok(true);
        }

        [HttpDelete("RemoverCompra/{id}")]
        public async Task<bool> RemoverCompra(int id)
        {
            bool removido = await _compraRepository.Remover(id);
            return removido;
        }
    }
}
