using Newtonsoft.Json;
using LaverieEntities.Entities;
using System.Collections.Generic;
using System.IO;
using Simulateur.Domain.Services;
namespace Simulateur.Infrastructure
{


    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LaverieData> GetLaverieDataAsync()
        {
            var response = await _httpClient.GetAsync("url_de_lapi");
            response.EnsureSuccessStatusCode();

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LaverieData>(jsonData);
        }
    }
}



 
