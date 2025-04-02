using MakeStore.Application.DTOs;
using MakeStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MakeStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var userId = await _usuarioService.CadastrarUsuarioAsync(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);
            return Ok(new { Id = userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var resultado = await _usuarioService.ValidarLoginAsync(loginDto.Email, loginDto.Senha);
            if (resultado)
            {
                return Ok(new { message = "Login realizado com sucesso!" });
            }
            return Unauthorized(new { message = "E-mail ou senha inválidos." });
        }

    }
}
