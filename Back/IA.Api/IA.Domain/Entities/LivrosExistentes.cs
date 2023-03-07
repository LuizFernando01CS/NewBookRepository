namespace IA.Domain.Entities
{
    public class LivrosExistentes : EntityBase
    {
        public string Resumo { get; private set; }
        public string Sumario { get; private set; }
        public string NomeLivroCompleto { get; private set; }
        public string Genero { get; private set; }

    }
}