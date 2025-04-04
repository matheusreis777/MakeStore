using MakeStore.Application.DTOs;
using MakeStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace MakeStore.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _config;
        private readonly AuthService _authService;

        public UsuarioController(
            IUsuarioService usuarioService, 
            IConfiguration config,
            AuthService authService)
        {
            _usuarioService = usuarioService;
            _config = config;
            _authService = authService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var userId = await _usuarioService.CadastrarUsuarioAsync(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);
            return Ok(new { Id = userId });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var resultado = await _usuarioService.ValidarLoginAsync(loginDto.Email, loginDto.Senha);
            if (resultado)
            {
                var token = _authService.GenerateToken(loginDto.Email);
                return Ok(new
                {
                    message = "Login realizado com sucesso!",
                    token = token
                });
            }
            return Unauthorized(new { message = "E-mail ou senha inválidos." });
        }

        [HttpGet("ObterUsuario/{email}")]
        [Authorize]
        public async Task<IActionResult> ObterUsuario(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email inválido");
            }
            var usuario = await _usuarioService.ObterUsuarioPorEmailAsync(email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(usuario);
        }
    }
}
