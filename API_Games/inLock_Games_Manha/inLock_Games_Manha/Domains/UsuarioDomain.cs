namespace inLock_Games_Manha.Domains
{
    /// <summary>
    /// classe que representa nossa entidade usuario em nosso banco de dados
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string? IdTipoUsuario { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
