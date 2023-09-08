using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using System.Data.SqlClient;

namespace inLock_Games_Manha.Repositories
{
    public class JogosRepository : IJogosRepository
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
        /// Método para realizar a criação de um cadastro de um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void cadastrar(JogosDomain novoJogo)
        {
            //realizar a conexão usando a string de conexão 
            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                //inserir os dados para realizar um novo cadastro de jogos
                string queryInsertJogo = "INSERT INTO Jogo (IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                //vamos declarar o comando a ser executado para esta conexão 
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsertJogo, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Método criado para realizar a listagem de todos os jogos dentro do sistema
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<JogosDomain> ListarTodos()
        {
            //precisa se conectar com o banco de dados para realizar a criação dos comandos
            //precisamos criar uma lista de objetos com os filmes que tenho no banco de dados

            List<JogosDomain> ListarJogos = new List<JogosDomain>();

            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome, Descricao, DataLancamento, Valor, Estudio.Nome AS Estudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, conn))
                {
                    rdr = cmd.ExecuteReader();

                     while (rdr.Read())
                    {
                        JogosDomain listaJogos = new JogosDomain()
                        {
                            Nome = rdr["Nome"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDouble(rdr["Valor"]),

                            Estudio = new StudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Estudio"].ToString()
                            }
                        };

                        

                        ListarJogos.Add(listaJogos);
                    }
                }
                return ListarJogos;
            }
        }
    }
}
