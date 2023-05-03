using IA.Api.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace IA.Api.Service
{
    public class IAService : IIAService
    {
        private readonly string _urlBase;
        private static readonly HttpClient client = new HttpClient();

        public IAService(IConfiguration configuration) => _urlBase = configuration.GetSection("IAService:Url").Value;

        public async Task CriarIA(int usuarioId, string token)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            await client.PostAsync($"{_urlBase}IA/CriarIA/{usuarioId}", null);
        }
    }
}