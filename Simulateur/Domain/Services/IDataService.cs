using LaverieEntities.Entities;

namespace Simulateur.Domain.Services
{
    public interface IDataServices
    {
        Task<List<Proprietaire>> GetProprietairesAsync();
        Task<List<Laveries>> GetLaveriesForProprietaireAsync(int cin);
        Task<List<Machine>> GetMachinesForLaverieAsync(int idLaverie);
        Task<List<Cycle>> GetCyclesForMachineAsync(int idMachine);

    }
}
