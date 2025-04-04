namespace MakeStore.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();

        public void DefinirSenha(string senha)
        {
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool ValidarSenha(string senhaOther)
        {
            return BCrypt.Net.BCrypt.Verify(senhaOther, SenhaHash);
        }

        public Usuario()
        {
            Id = Guid.NewGuid();
            Nome = "Matheus Testando";
            Email = "testando@gmail.com";
            Produtos = new List<Produto>();
            Compras = new List<Compra>();
            DefinirSenha("Teste@123");
        }
    }
}
