﻿namespace MakeStore.Application.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        ProdutoDto Produto{ get; set; } = new ProdutoDto();
    }
}
