using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesService
    {
        Task<int> Create(TramiteModel tramite);
        Task<int> Delete(string tramiteId);
        Task<int> Update(TramiteModel tramite);
        Task<List<TramiteModel>> GetTramites();
        Task<TramiteModel> GetTramite(string tramiteId);
    }
}
