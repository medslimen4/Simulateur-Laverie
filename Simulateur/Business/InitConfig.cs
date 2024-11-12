using LaverieEntities.Entities;
using Simulateur.Domain.Services;
using Simulateur.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.Business
{
    public class InitConfig
    {
        private readonly DataService _dataService;

        // Injecter DataService pour récupérer les données dans la couche Infrastructure
        public InitConfig(DataService dataService)
        {
            _dataService = dataService;
        }

        // Configurer les entités pour la simulation de laverie
        public async Task<SimulationConfig> InitializeConfigurationAsync()
        {
            // Récupérer les données de l'API
            LaverieData laverieData = await _dataService.GetLaverieDataAsync();

            // Configurer les relations entre les entités
            foreach (var laverie in laverieData.Laveries)
            {
                // Associer chaque machine à sa laverie et chaque cycle à sa machine
                laverie.machinesLaverie = laverieData.Machines.FindAll(m => m.IDLaverie == laverie.IdLaverie);

                foreach (var machine in laverie.machinesLaverie)
                {
                    machine.cyclesMachine = laverieData.Cycles.FindAll(c => c.IdMachine == machine.IdMachine);
                    machine.Laverie = laverie;
                }

                // Associer chaque laverie à son propriétaire
                var proprietaire = laverieData.Proprietaires.Find(p => p._CIN == laverie.ProprietaireCIN);
                if (proprietaire != null)
                {
                    laverie.Proprietaire = proprietaire;
                    proprietaire.propLaverie.Add(laverie);
                }
            }

            // Créer la configuration pour la simulation
            SimulationConfig config = new SimulationConfig
            {
                Proprietaires = laverieData.Proprietaires,
                Laveries = laverieData.Laveries,
                Machines = laverieData.Machines,
                Cycles = laverieData.Cycles
            };

            return config;
        }
    }

    public class SimulationConfig
    {
        public List<Proprietaire> Proprietaires { get; set; }
        public List<Laveries> Laveries { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Cycle> Cycles { get; set; }
    }
}
