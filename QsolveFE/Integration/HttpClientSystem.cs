using QsolveFE.Services;
using Newtonsoft.Json;
using QsolveFE.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace QsolveFE.Integration
{
    public class HttpClientSystem : IHttpClientSystem
    {
        private readonly HttpClient _client;
        public HttpClientSystem(HttpClient client)
        {
            _client = client;

            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7040/api/Weather")
            };
        }

        public async Task<TResponse> GetRequest<TResponse>(string url)
        {
            var fullUrl = string.Format($"{_client.BaseAddress}/{url}");
            var response = await _client.GetAsync(fullUrl);
            var stringResponse = await response.Content.ReadAsStringAsync();
            TResponse myDeserializedClass = JsonConvert.DeserializeObject<TResponse>(stringResponse);

            return myDeserializedClass;
        }

       public async Task<TResponse> PostRequest<TResponse>([FromBody] WeatherDTO dto, string url)
       {
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_client.BaseAddress}/{url}", data);

            string result = await response.Content.ReadAsStringAsync();
            TResponse myDeserializedClass = JsonConvert.DeserializeObject<TResponse>(result);
            return myDeserializedClass;
        }

        public async Task<TResponse> PostRequest<TResponse>(Guid id, string url)
        { 
            var response = await _client.DeleteAsync($"{_client.BaseAddress}/{url}?id={id}");
            string result = await response.Content.ReadAsStringAsync();
            TResponse myDeserializedClass = JsonConvert.DeserializeObject<TResponse>(result);
            return myDeserializedClass;
        }

        public async Task<TResponse> PutRequest<TResponse>(WeatherDTO dto, string url)
        {
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{_client.BaseAddress}/{url}", data);

            string result = await response.Content.ReadAsStringAsync();
            TResponse myDeserializedClass = JsonConvert.DeserializeObject<TResponse>(result);
            return myDeserializedClass;
        }

    }
}
