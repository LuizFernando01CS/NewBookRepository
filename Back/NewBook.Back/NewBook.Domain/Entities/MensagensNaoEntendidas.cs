using NewBook.Domain.Enums;

namespace NewBook.Domain.Entities
{
    public class MensagensNaoEntendidas : EntityBase
    {
        public int? MensagensId { get; set; }
        public string MensagemRecebida { get; set; }

        public StatusEntendimentoEnum StatusEntendimento { get; set; }

        public Mensagens Mensagens { get; set; }
    }
}