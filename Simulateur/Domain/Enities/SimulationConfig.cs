using LaverieEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.Domain.Enities
{
    public class SimulationConfig
    {
        public List<Proprietaire> Proprietaires { get; set; }
        public List<Laveries> Laveries { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Cycle> Cycles { get; set; }
    }
}
