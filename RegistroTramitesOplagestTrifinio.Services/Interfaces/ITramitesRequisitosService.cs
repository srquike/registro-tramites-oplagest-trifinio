using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesRequisitosService
    {
        Task<int> UpdateMany(ICollection<TramiteRequisitoModel> requisitos);
    }
}
