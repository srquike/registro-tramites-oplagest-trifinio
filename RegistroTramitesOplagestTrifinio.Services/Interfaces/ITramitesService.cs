using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesService
    {
        Task<int> Create(TramiteModel tramite);
        Task<int> Delete(TramiteModel tramite);
        Task<int> Update(TramiteModel tramite);
        Task<int> Find(int tramiteId);
        Task<List<TramiteModel>> GetTramites();
        Task<List<TramiteModel>> GetTramitesByEstado(string filter);
        Task<TramiteModel> GetTramite(int tramiteId);
        Task<List<DepartamentoModel>> GetDepartamentosAsync();
        Task<List<MunicipioModel>> GetMunicipiosByDepartamentoAsync(int departamentoId);
    }
}
