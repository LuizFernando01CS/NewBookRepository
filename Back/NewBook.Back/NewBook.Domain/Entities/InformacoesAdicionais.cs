using NewBook.Domain.Enums;

namespace NewBook.Domain.Entities
{
    public class InformacoesAdicionais : EntityBase
    {
        public InformacoesAdicionais()
        {
            SetandoBasePeloSite();
        }

        public bool LivrosCriados { get; set; }
        public FrequenciaEscritaEnum FrequenciaEscrita { get; set; } = FrequenciaEscritaEnum.NuncaEscreveu;
        public bool JaEscreveu { get; set; }
        public int? GostosLivroExistenteId { get; set; } = 0;
        public int? LidosLivrosExistenteId { get; set; } = 0;

        public List<Usuario> Usuario { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}