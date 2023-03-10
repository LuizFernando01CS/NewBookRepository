namespace NewBook.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int InformacoesPessoaisID { get; set; }

        public List<ChatIA> ChatIA { get; set; }
        public InformacoesPessoais InformacoesPessoais { get; set; }
    }
}