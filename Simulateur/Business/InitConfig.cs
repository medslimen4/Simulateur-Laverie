using LaverieEntities.Entities;
using Simulateur.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.Business
{
    public class InitConfig
    {
        private readonly IDataServices _dataServices;

        public InitConfig(IDataServices dataServices)
        {
            _dataServices = dataServices;
        }

        public async Task<List<Proprietaire>> InitialiserDonnees()
        {
            try
            {
                var proprietaires = await _dataServices.GetProprietairesAsync();
                foreach (var prop in proprietaires)
                {
                    prop.propLaverie = await _dataServices.GetLaveriesForProprietaireAsync(prop._CIN);
                    foreach (var laverie in prop.propLaverie)
                    {
                        laverie.machinesLaverie = await _dataServices.GetMachinesForLaverieAsync(laverie.IdLaverie);
                        foreach (var machine in laverie.machinesLaverie)
                        {
                            machine.cyclesMachine = await _dataServices.GetCyclesForMachineAsync(machine.IdMachine);
                        }
                    }
                }
                return proprietaires;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'initialisation des données: {ex.Message}");
                return new List<Proprietaire>();
            }
        }
    }
}
