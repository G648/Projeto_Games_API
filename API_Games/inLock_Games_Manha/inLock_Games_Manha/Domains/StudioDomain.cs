using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace inLock_Games_Manha.Domains
{
    /// <summary>
    /// classe que representa a entidade studio no nosso banco de dados
    /// </summary>
    public class StudioDomain
    {
        public int IdEstudio { get; set; }
        public string? Nome { get; set; }

        [JsonIgnore]
        public List<JogosDomain> Jogos { get; set; } 
    }
}
