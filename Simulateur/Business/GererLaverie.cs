using LaverieEntities.Entities;


namespace Simulateur.Business
{
    public class GererLaverie
    {
        private readonly List<Proprietaire> _proprietaires;

        public GererLaverie(List<Proprietaire> proprietaires)
        {
            _proprietaires = proprietaires;
        }

        public void SimulerFonctionnementLaverie()
        {
            foreach (var proprietaire in _proprietaires)
            {
                Console.WriteLine($"Propriétaire: {proprietaire._Surname} (CIN: {proprietaire._CIN})");

                foreach (var laverie in proprietaire.propLaverie)
                {
                    Console.WriteLine($"\tLaverie: {laverie.AddresseLaverie} (Capacité: {laverie.CapaciteLaverie})");

                    foreach (var machine in laverie.machinesLaverie)
                    {
                        Console.WriteLine($"\t\tMachine: {machine.MarqueMachine} (État: {machine.EtatMachine})");

                        foreach (var cycle in machine.cyclesMachine)
                        {
                            Console.WriteLine($"\t\t\tCycle: {cycle.NomCycle} - {cycle.DureeCycleHR}h - {cycle.coutCycle}€");
                        }
                    }
                }
            }
        }

        public void SimulerCycle(int idMachine, int idCycle)
        {
            var machine = _proprietaires
                .SelectMany(p => p.propLaverie)
                .SelectMany(l => l.machinesLaverie)
                .FirstOrDefault(m => m.IdMachine == idMachine);

            if (machine == null)
            {
                Console.WriteLine("Machine non trouvée");
                return;
            }

            var cycle = machine.cyclesMachine.FirstOrDefault(c => c.IdCycle == idCycle);
            if (cycle == null)
            {
                Console.WriteLine("Cycle non trouvé");
                return;
            }

            Console.WriteLine($"Démarrage du cycle {cycle.NomCycle} sur la machine {machine.MarqueMachine}");
            Console.WriteLine($"Durée estimée: {cycle.DureeCycleHR} heures");
            Console.WriteLine($"Coût: {cycle.coutCycle}€");
        }
    }

}
