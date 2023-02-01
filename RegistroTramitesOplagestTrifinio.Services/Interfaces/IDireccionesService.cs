using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IDireccionesService
    {
        Task<int> UpdateAsync(DireccionModel direccion);
    }
}
