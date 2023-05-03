using IA.Core.Enums;

namespace IA.Domain.Entities
{
    public class Permissao : EntityBase
    {
        public PermissaoEnum PermissaoMicrofone { get; set; }
        public PermissaoEnum PermissaoFone { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}