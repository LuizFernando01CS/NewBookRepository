namespace IA.Domain.Entities
{
    public class ChatIA : EntityBase
    {
        public ChatIA(){}

        public ChatIA(Usuario usuario, int usuarioId)
        {
            UsuarioId = usuarioId;
            SetandoBasePeloSite();
        }

        public int? UsuarioId { get; set; }

        public List<Mensagens> Mensagens { get; set; }
        public Usuario Usuario { get; set; }
    }
}