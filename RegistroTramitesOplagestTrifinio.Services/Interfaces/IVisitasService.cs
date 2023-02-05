using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IVisitasService
    {
        Task<int> Create(VisitaModel visita);
        Task<VisitaModel> GetVisitaAsync(int id);
        public IQueryable<VisitaModel> GetVisitasAsync();
        Task<int> UpdateAsync(VisitaModel visita);
        //Task<int> Delete(TramiteModel tramite);
        //Task<int> Update(TramiteModel tramite);
        //Task<List<TramiteModel>> GetTramites();
        //Task<List<TramiteModel>> GetTramitesByFilter(string filter);
        //Task<TramiteModel> GetTramite(int tramiteId);
    }
}
