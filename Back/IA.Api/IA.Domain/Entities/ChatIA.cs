namespace IA.Domain.Entities
{
    public class ChatIA : EntityBase
    {
        public int UsuarioId { get; set; }


        public List<Mensagens> Mensagens { get; set; }
        public Usuario Usuario { get; set; }
    }
}