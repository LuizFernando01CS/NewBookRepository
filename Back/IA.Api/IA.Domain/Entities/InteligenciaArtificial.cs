using IA.Core.Enums;

namespace IA.Domain.Entities
{
    public class InteligenciaArtificial : EntityBase
    {
        public InteligenciaArtificial()
        {
            SetandoBasePeloSite();
        }

        public InteligenciaArtificial(int usuarioId)
        {
            SetandoBasePeloSite();
            NomeIA = "Shifter";
            TipoVoz = TipoVozIAEnum.Default;
            Estilizado = false;
            TipoEstilizado = TipoEstilizadoEnum.Default;
            UsuarioId = usuarioId;
            CorMensagemUsuario = "lightgreen";
            CorMensagemIA = "rgb(207, 207, 207)";
        }

        public string NomeIA { get; set; }
        public TipoVozIAEnum TipoVoz { get; set; }
        public bool Estilizado { get; set; }
        public TipoEstilizadoEnum TipoEstilizado { get; set; }
        public string CorMensagemUsuario { get; set; }
        public string CorMensagemIA { get; set; }
        public string CorChatIA { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}