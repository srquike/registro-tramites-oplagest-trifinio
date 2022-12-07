using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesService
    {
        Task<int> Create(TramiteModel tramite);
        Task<int> Delete(TramiteModel tramite);
        Task<int> Update(TramiteModel tramite);
        Task<List<TramiteModel>> GetTramites();
        Task<TramiteModel> GetTramite(int tramiteId);
    }
}
