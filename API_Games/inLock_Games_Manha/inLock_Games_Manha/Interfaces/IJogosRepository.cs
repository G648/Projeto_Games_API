using inLock_Games_Manha.Domains;

namespace inLock_Games_Manha.Interfaces
{
    public interface IJogosRepository
    {
        /// <summary>
        /// Método para realizar a criação de cadastro de um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto que será cadastrado</param>
        void cadastrar(JogosDomain novoJogo);

        /// <summary>
        /// Método para realizar a listagem de todos os jogos dentro do nosso sitema
        /// </summary>
        /// <returns>Objeto que será listado</returns>
        List<JogosDomain> ListarTodos();

        /// <summary>
        /// Método para realziar o delete de um deterinado jogo
        /// </summary>
        /// <param name="IdJogo"></param>
        void deletar (int id);
    }
}
