using MakeStore.Application.Interfaces;
using MakeStore.Domain.Entities;
using MakeStore.Domain.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MakeStore.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> CadastrarUsuarioAsync(string nome, string email, string senha)
        {
            var usuario = new Usuario
            {
                Nome = nome,
                Email = email
            };

            usuario.DefinirSenha(senha); // Aqui a senha é hashada corretamente

            await _usuarioRepository.AdicionarAsync(usuario);
            return usuario.Id;
        }

        private string HashSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public async Task<bool> ValidarLoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            return usuario != null && usuario.ValidarSenha(senha);
        }
    }
}
