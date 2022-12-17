using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IDevolucionesService
    {
        Task<int> Create(DevolucionModel devolucion);
    }
}
