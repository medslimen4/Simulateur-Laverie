using System.Threading.Tasks;
using LaverieEntities.Entities;
using System.Collections.Generic;

namespace Simulateur.Business
{
    public class GererLaverie
    {
        private readonly SimulationConfig _config;

        // Constructeur avec injection de la configuration de simulation
        public GererLaverie(SimulationConfig config)
        {
            _config = config;
        }

        // Méthode pour démarrer la simulation de la laverie
        public async Task StartSimulationAsync()
        {
            // Appliquer les règles métier sur les laveries et machines
            foreach (var laverie in _config.Laveries)
            {
                // Logique métier pour chaque laverie
                ProcessLaverie(laverie);
            }

            // Simuler d'autres aspects de la laverie
            foreach (var machine in _config.Machines)
            {
                ProcessMachine(machine);
            }
        }

        private void ProcessLaverie(Laveries laverie)
        {
            // Exemple : Calculer la capacité utilisée de la laverie
            Console.WriteLine($"Simuler la laverie {laverie.IdLaverie} avec la capacité {laverie.CapaciteLaverie}");

            foreach (var machine in laverie.machinesLaverie)
            {
                // Traitement des machines de la laverie
                ProcessMachine(machine);
            }
        }

        private void ProcessMachine(Machine machine)
        {
            // Exemple : Vérification de l'état de la machine et gestion des cycles
            Console.WriteLine($"- Machine {machine.IdMachine} ({machine.MarqueMachine})");

            foreach (var cycle in machine.cyclesMachine)
            {
                // Simuler les cycles de la machine
                ProcessCycle(cycle);
            }
        }

        private void ProcessCycle(Cycle cycle)
        {
            // Exemple : Calculer le coût total, la durée, etc.
            Console.WriteLine($"  - Cycle {cycle.IdCycle}: {cycle.NomCycle} ({cycle.DureeCycleHR} heures, {cycle.coutCycle}€)");
        }
    }
}
