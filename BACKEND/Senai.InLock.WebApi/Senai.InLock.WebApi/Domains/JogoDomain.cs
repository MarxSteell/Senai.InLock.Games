using System;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int JogoId { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public Decimal Valor { get; set; }
        public int EstudioId { get; set; }
        public EstudioDomain Estudio { get; set; }
    }
}
