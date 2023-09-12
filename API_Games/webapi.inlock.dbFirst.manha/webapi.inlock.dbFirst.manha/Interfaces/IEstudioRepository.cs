using webapi.inlock.dbFirst.manha.Domains;

namespace webapi.inlock.dbFirst.manha.Interfaces
{
    public interface IEstudioRepository
    {
        //classe para realizar a implementação dos métodos

        List<Estudio> listar();

        Estudio BuscarPorId(Guid id);

        void Cadastrar (Estudio estudio);

        void Atualizar(Guid id, Estudio estudio);

        void Deletar(Guid id);

        List<Estudio> ListarComJogos();
    }
}
