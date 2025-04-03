namespace MakeStore.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public ICollection<Produto> Produtos { get; set; }

        public void DefinirSenha(string senha)
        {
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool ValidarSenha(string senhaOther)
        {
            return BCrypt.Net.BCrypt.Verify(senhaOther, SenhaHash);
        }
    }
}
