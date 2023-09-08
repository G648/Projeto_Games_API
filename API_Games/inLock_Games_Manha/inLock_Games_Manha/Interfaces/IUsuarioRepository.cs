using inLock_Games_Manha.Domains;

namespace inLock_Games_Manha.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// classe para cadastrar novos usuários no sistema
        /// </summary>
        /// <param name="novoUsuario">Objeto que será cadastrado</param>
        UsuarioDomain Login(string Email, string Senha);
    }
}
