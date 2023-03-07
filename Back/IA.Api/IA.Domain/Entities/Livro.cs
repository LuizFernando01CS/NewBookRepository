namespace IA.Domain.Entities
{
    public class Livro : EntityBase
    {
        public string Resumo { get; set; }
        public string Sumario { get; set; }
        public string LivroCompleto { get; set; }
        public int UsuarioId { get; set; }
        public int TipoLivroId { get; set; }
    }
}