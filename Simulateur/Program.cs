using Microsoft.Extensions.DependencyInjection;
using Simulateur.Business;
using Simulateur.Domain.Services;
using Simulateur.Infrastructure;

class Program
{
    static async Task Main(string[] args)
    {
        // Configuration des services
        var services = new ServiceCollection();
        services.AddHttpClient();
        services.AddScoped<IDataServices, DataServices>();
        services.AddScoped<InitConfig>();

        var serviceProvider = services.BuildServiceProvider();

        // Initialisation des données
        var initConfig = serviceProvider.GetRequiredService<InitConfig>();
        var proprietaires = await initConfig.InitialiserDonnees();

        // Création du gestionnaire de laverie
        var gestionLaverie = new GererLaverie(proprietaires);

        // Simulation
        gestionLaverie.SimulerFonctionnementLaverie();

        gestionLaverie.SimulerCycle(1, 1); // Simuler le cycle 1 sur la machine 1
    }
}