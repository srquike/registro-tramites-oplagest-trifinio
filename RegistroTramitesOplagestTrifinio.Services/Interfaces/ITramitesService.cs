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
        Task<List<TramiteRequisitoModel>> GetRequisitosByTramiteAsync(int tramiteId);
        Task<List<ProyectoModel>> GetProyectosAsync();
        Task<int> CreateProyectoAsync(ProyectoModel proyecto);
        Task<int> CreateManyRequisitosAsync(List<TramiteRequisitoModel> requisitos);
        Task<List<InmuebleModel>> GetInmueblesAsync();
        Task<int> CreateInmuebleAsync(InmuebleModel inmueble);
        Task<InmuebleModel> GetInmuebleAsync(int inmuebleId);
        Task<int> UpdateInmuebleAsync(InmuebleModel inmueble);
    }
}
