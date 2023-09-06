using inLock_Games_Manha.Domains;

namespace inLock_Games_Manha.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para cadastrar novos usuários no sistema
        /// </summary>
        /// <param name="novoUsuario">Objeto que será cadastrado</param>
        void cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// método para realizar a listagem dos usuarios dentro do sistema
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<UsuarioDomain> ListarUser();   
    }
}
