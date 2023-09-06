namespace inLock_Games_Manha.Domains
{
    /// <summary>
    ///  Classe que representa nossa tabela jogos no banco de dados
    /// </summary>
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public double Valor { get; set; }
        public StudioDomain Estudio { get; set; }
    }
}
