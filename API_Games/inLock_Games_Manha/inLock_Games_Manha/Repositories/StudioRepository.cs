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

        private string stringconexao = "data source = NOTE16-S15; initial catalog = inlock_games_manha; user id = sa; pwd = Senai@134; trustservercertificate = true";
        //private string stringConexao = "Data Source = AMORIM\\SQLEXPRESS; Initial Catalog = inlock_games_manha; User id = sa; pwd = Senai@134; TrustServerCertificate = true";

        /// <summary>
        /// Método para realizar o cadastro de novos studios
        /// </summary>
        /// <param name="novoStudio"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void cadastrar(StudioDomain novoStudio)
        {
            using (SqlConnection conn = new SqlConnection(stringconexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoStudio.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para visualizar os studios criados
        /// </summary>
        /// <returns>lista de studios</returns>
        public List<StudioDomain> ListarTodos()
        {
            List<StudioDomain> listaEstudios = new List<StudioDomain>();

            using (SqlConnection conn = new SqlConnection(stringconexao))
            {
                string querySelectAll = "SELECT Estudio.IdEstudio, Estudio.Nome AS Estudio, IdJogo, Jogo.Nome AS Jogo, Descricao, DataLancamento, Valor FROM Estudio LEFT JOIN Jogo ON Jogo.IdEstudio = Estudio.IdEstudio ORDER BY Estudio.IdEstudio";


                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, conn))
                {
                    rdr = cmd.ExecuteReader();

                    Dictionary<int, StudioDomain> estudiosDict = new Dictionary<int, StudioDomain>();

                    while (rdr.Read())
                    {
                        int idEstudio = Convert.ToInt32(rdr["IdEstudio"]);

                        if (!estudiosDict.ContainsKey(idEstudio))
                        {
                            StudioDomain estudio = new StudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = Convert.ToString(rdr["Estudio"]),

                                Jogos = new List<JogosDomain>()
                            };
                            estudiosDict.Add(idEstudio, estudio);
                        }

                        JogosDomain jogos = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = Convert.ToString(rdr["Jogo"]),

                            Descricao = Convert.ToString(rdr["Descricao"]),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };

                        estudiosDict[idEstudio].Jogos.Add(jogos);

                        listaEstudios = estudiosDict.Values.ToList();
                    }
                }
            }
            return listaEstudios;
        }
    }
}

