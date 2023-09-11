using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using System.Data.SqlClient;

namespace inLock_Games_Manha.Repositories
{

    //vamos criar os métodos cadastrar e listar que estão vindo da interface de usuario
    public class UsuarioRepository : IUsuarioRepository
    {
        //antes de tudo, vamos chamar nossa string de conexão para conseguirmos executar os comandos de banco de dados
        private string stringconexao = "data source = NOTE16-S15; initial catalog = inlock_games_manha; user id = sa; pwd = Senai@134; trustservercertificate = true";
        //private string stringConexao = "Data Source = AMORIM\\SQLEXPRESS; Initial Catalog = inlock_games_manha; User id = sa; pwd = Senai@134; TrustServerCertificate = true";

        /// <summary>
        /// Método para retornar o usuario buscado com um método de login passando como parâmetro o email e a senha do usuario
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns>Usuario buscado</returns>
        public UsuarioDomain Login(string Email, string Senha)
        {
            //realizando a criação da string de conexão:
            using (SqlConnection conn = new SqlConnection(stringconexao))
            {
                //criando nossa string de banco de dados
                string querySelect = "SELECT IdUsuario, Usuario.IdTipoUsuario, Email, Senha, TiposUsuario.Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            Titulo = new TiposUsuarioDomain()
                            {
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
