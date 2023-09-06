using inLock_Games_Manha.Domains;

namespace inLock_Games_Manha.Interfaces
{
    public interface IStudioRepository
    {
        /// <summary>
        /// Método para realizar o cadastro de um novo Studio
        /// </summary>
        /// <param name="novoStudio">Objeto que será cadastrado</param>
        void cadastrar (StudioDomain novoStudio);

        /// <summary>
        /// Método para realizar a listagem de todos os studios dentro do nosso sistema
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<StudioDomain> ListarTodos();   
    }
}
