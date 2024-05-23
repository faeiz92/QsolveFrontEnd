using Microsoft.AspNetCore.Mvc;
using QsolveFE.Integration;

namespace QsolveFE.Services
{
    public interface IHttpClientSystem
    {
        Task<TResponse> GetRequest<TResponse>(string url);
        Task<TResponse> PostRequest<TResponse>(WeatherDTO dto, string url);
        Task<TResponse> PostRequest<TResponse>(Guid id, string url);
        Task<TResponse> PutRequest<TResponse>(WeatherDTO dto, string url);
    }
}
