using InfraStructure.DTOs;
using LavadTesting.Infrastructure.DTOs;
using LavadTesting.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace InfraStructure.Services
{
    public class HttpClientCrudService
    {
        private readonly HttpClient httpClient;

        private readonly JsonSerializerOptions _options;

        public HttpClientCrudService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.Timeout = new TimeSpan(0, 0, 30);
            this.httpClient.BaseAddress = new Uri("https://lavad-lookups-api-dev.azurewebsites.net/");
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IList<SocialPlatformDTO>> Execute()
        {
            var response = await GetSocialPlatforms();
            return response;
        }
        public async Task<IList<SocialPlatformDTO>> GetSocialPlatforms()
        {
            var httpResponseMessage = await httpClient.GetAsync("api/lookups/SocialPlatform");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                 var SocialPlatforms = JsonSerializer.Deserialize<SocialPlatformResponseDTO>(content,_options);
                return SocialPlatforms.Response;
            }
            return null;
        }
    }
}




