using Newtonsoft.Json;
using LaverieEntities.Entities;
using System.Collections.Generic;
using System.IO;
using Simulateur.Domain.Services;
namespace Simulateur.Infrastructure
{

    public class DataServices : IDataServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api_url";

        public DataServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Proprietaire>> GetProprietairesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/proprietaires");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Proprietaire>>(content);
        }

        public async Task<List<Laveries>> GetLaveriesForProprietaireAsync(int cin)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/proprietaires/{cin}/laveries");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Laveries>>(content);
        }

        public async Task<List<Machine>> GetMachinesForLaverieAsync(int idLaverie)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/laveries/{idLaverie}/machines");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Machine>>(content);
        }

        public async Task<List<Cycle>> GetCyclesForMachineAsync(int idMachine)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/machines/{idMachine}/cycles");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Cycle>>(content);
        }


    }
}



 
