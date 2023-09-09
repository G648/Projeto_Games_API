using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace inLock_Games_Manha.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do Servidor
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação com o windowns
        /// private string stringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes; Integrated Security = true";
        /// </summary>
        /// 
        //Autenticação com o SQL Server

        //private string stringConexao = "Data Source = NOTE16-S15; Initial Catalog = inlock_games_manha; User id = sa; pwd = Senai@134; TrustServerCertificate = true";
        private string stringConexao = "Data Source = AMORIM\\SQLEXPRESS; Initial Catalog = inlock_games_manha; User id = sa; pwd = Senai@134; TrustServerCertificate = true";

        /// <summary>
        /// Método para realizar o cadastro de novos studios
        /// </summary>
        /// <param name="novoStudio"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void cadastrar(StudioDomain novoStudio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para visualizar os studios criados
        /// </summary>
        /// <returns>lista de studios</returns>
        public List<StudioDomain> ListarTodos()
        {
            List<StudioDomain> listarTodos = new List<StudioDomain>();

            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio ";

                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, conn))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        StudioDomain listarStudio = new StudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString()
                        };

                        listarTodos.Add(listarStudio);
                    }
                }
                return listarTodos;
            }
        }
    }
}
