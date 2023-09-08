using System.ComponentModel.DataAnnotations;

namespace inLock_Games_Manha.Domains
{
    /// <summary>
    /// classe que representa nossa entidade usuario em nosso banco de dados
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="O nome do campo é obrigatório")]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage ="A senha deve ter entre 5 e 20 caracteres")]
        public string? Senha { get; set; }
    }
}
