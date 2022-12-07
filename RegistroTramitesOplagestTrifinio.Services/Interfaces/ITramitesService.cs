using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesService
    {
        Task<int> Create(TramiteModel tramite);
        Task<int> Delete(int tramiteId);
        Task<int> Update(int tramiteId, TramiteModel tramite);
        Task<List<TramiteModel>> GetTramites();
        Task<TramiteModel> GetTramite(int tramiteId);
    }
}
