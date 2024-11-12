using Microsoft.Extensions.DependencyInjection;
using Simulateur.Business;
using Simulateur.Domain.Services;
using Simulateur.Infrastructure;

public class Program
{
    public static async Task Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        DataService dataService = new DataService(httpClient);

        // Initialisation de InitConfig et récupération de la configuration
        InitConfig initConfig = new InitConfig(dataService);
        SimulationConfig config = await initConfig.InitializeConfigurationAsync();

        // Initialisation de GererLaverie et démarrage de la simulation
        GererLaverie gererLaverie = new GererLaverie(config);
        await gererLaverie.StartSimulationAsync();
    }
}
