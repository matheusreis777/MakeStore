namespace MakeStore.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Guid> CadastrarUsuarioAsync(string nome, string email, string senha);
        Task<bool> ValidarLoginAsync(string email, string senha);
    }
}
