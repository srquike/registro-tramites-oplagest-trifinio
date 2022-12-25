using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IActividadesService
    {
        Task<int> CreateAsync(ActividadModel model);
        Task<List<ActividadModel>> GetActividadesAsync();
        IQueryable<ActividadModel> GetActividadesQueryable();
    }
}
