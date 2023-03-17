using NewBook.Domain.Enums;

namespace NewBook.Domain.Entities
{
    public class Mensagens : EntityBase
    {
        public string Mensagem { get; set; }
        public TipoMensagemEnum TipoMensagem { get; set; }
        public int Ordem { get; set; }
        public int? ChatIAId { get; set; }


        public ChatIA ChatIA { get; set; }
        public List<MensagensNaoEntendidas> MensagensNaoEntendidas { get; set; }
    }
}