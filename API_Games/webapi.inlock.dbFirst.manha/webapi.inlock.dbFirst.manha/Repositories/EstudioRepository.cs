using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //realizar instancia do inlockContext
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Método responsável para atualizar uma informação no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudio"></param>
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para realizar a busca de um determinado dado no nosso sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Estudio BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para realizar o cadastro de um novo estudio
        /// </summary>
        /// <param name="estudio"></param>
        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método pra deletar um Estudio criado
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para listar os estudios criados
        /// </summary>
        /// <returns></returns>
        public List<Estudio> listar()
        {
            return ctx.Estudios.ToList();
        }

        /// <summary>
        /// Método para retornar os jogos na hora de listar os Estudios
        /// </summary>
        /// <returns></returns>
        public List<Estudio> ListarComJogos()
        {
            //vamos instanciar aqui uma expressão lambda através do include. Para assim conseguirmos pegar uma lista de jogos dentro do Estudio
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
