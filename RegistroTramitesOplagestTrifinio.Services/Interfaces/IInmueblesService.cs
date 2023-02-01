using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IInmueblesService
    {
        Task<int> CreateAsync(InmuebleModel inmueble);
        Task<InmuebleModel> GetInmuebleAsync(int id);
        Task<List<InmuebleModel>> GetInmueblesAsync();
        Task<int> UpdateAsync(InmuebleModel inmueble);
    }
}
