using Xunit;
using MakeStore.Domain.Entities;
using System;

namespace MakeStore.Tests.Domain.Entities
{
    public class UsuarioTests
    {
        [Fact]
        public void Usuario_DeveSerCriadoComValoresPadrao()
        {
            // Act
            var usuario = new Usuario();

            // Assert
            Assert.Equal("Matheus Testando", usuario.Nome);
            Assert.Equal("testando@gmail.com", usuario.Email);
            Assert.True(usuario.ValidarSenha("Teste@123"));
            Assert.NotNull(usuario.Produtos);
            Assert.NotNull(usuario.Compras);
            Assert.Empty(usuario.Produtos);
            Assert.Empty(usuario.Compras);
            Assert.NotEqual(Guid.Empty, usuario.Id);

        }

        [Fact]
        public void DefinirSenha_DeveGerarHashDiferenteDaSenhaOriginal()
        {
            // Arrange
            var usuario = new Usuario();
            string senha = "MinhaSenhaSegura123";

            // Act
            usuario.DefinirSenha(senha);

            // Assert
            Assert.NotEqual(senha, usuario.SenhaHash);
            Assert.True(usuario.ValidarSenha(senha)); // Senha deve ser validada corretamente
        }

        [Fact]
        public void ValidarSenha_DeveRetornarFalsoParaSenhaIncorreta()
        {
            // Arrange
            var usuario = new Usuario();
            usuario.DefinirSenha("SenhaCorreta");

            // Act
            bool resultado = usuario.ValidarSenha("SenhaErrada");

            // Assert
            Assert.False(resultado);
        }
    }
}
