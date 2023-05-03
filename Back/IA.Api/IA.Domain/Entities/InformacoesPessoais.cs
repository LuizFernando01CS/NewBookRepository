﻿namespace IA.Domain.Entities
{
    public class InformacoesPessoais : EntityBase
    {
        public string NomeAbreviado { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public int NumeroTelefone1 { get; set; }
        public int NumeroTelefone2 { get; set; }
        public DateTime Idade { get; set; }

        public List<Usuario> Usuario { get; set; }
    }
}