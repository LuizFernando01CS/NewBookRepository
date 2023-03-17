using NewBook.Domain.Enums;

namespace NewBook.Domain.Entities
{
    public class InformacoesAdicionais : EntityBase
    {
        public bool LivrosCriados { get; set; }
        public FrequenciaEscritaEnum FrequenciaEscrita { get; set; }
        public bool JaEscreveu { get; set; }
        public int? GostosLivroExistenteId { get; set; }
        public int? LidosLivrosExistenteId { get; set; }

        public List<InformacoesPessoais> InformacoesPessoais { get; set; }
    }
}