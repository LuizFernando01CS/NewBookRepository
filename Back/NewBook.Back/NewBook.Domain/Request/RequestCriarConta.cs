using NewBook.Domain.Enums;

namespace NewBook.Domain.Request
{
    public class RequestCriarConta
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NomeAbreviado { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public int NumeroTelefone1 { get; set; }
        public int NumeroTelefone2 { get; set; }
        public DateTime Idade { get; set; }
        public bool LivrosCriados { get; set; }
        public FrequenciaEscritaEnum FrequenciaEscrita { get; set; }
        public bool JaEscreveu { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }
    }
}