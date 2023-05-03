namespace IA.Api.Service.Interfaces
{
    public interface IIAService
    {
        Task CriarIA(int usuarioId, string token);
    }
}