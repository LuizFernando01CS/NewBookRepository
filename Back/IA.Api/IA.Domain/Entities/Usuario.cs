namespace IA.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? InformacoesPessoaisID { get; set; }
        public string FirebaseId { get; set; }
        public bool CreateAuthGoogle { get; set; }
        public string Imagem { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string ProvedorId { get; set; }
        public string MetodoAcesso { get; set; }

        public List<ChatIA> ChatIA { get; set; }
        public InformacoesPessoais InformacoesPessoais { get; set; }
    }
}