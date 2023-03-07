namespace NewBook.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }

        public List<InformacoesPessoais> InformacoesPessoais { get; set; }
    }
}