namespace IA.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? InformacoesPessoaisID { get; set; }
        public bool CreateAuthGoogle { get; set; }
        public string Imagem { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string ProvedorId { get; set; }
        public string MetodoAcesso { get; set; }
        public int? InformacoesAdicionaisId { get; set; }
        public int? EnderecoId { get; set; }

        public List<ChatIA> ChatIA { get; set; }
        public InformacoesPessoais InformacoesPessoais { get; set; }
        public InformacoesAdicionais InformacoesAdicionais { get; set; }
        public Endereco Endereco { get; set; }
        public List<InteligenciaArtificial> InteligenciaArtificial { get; set; }
        public List<Permissao> Permissao { get; set; }
    }
}