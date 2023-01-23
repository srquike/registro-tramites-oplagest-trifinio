using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface ITramitesRequisitosService
    {
        Task<int> UpdateManyAsync(List<TramiteRequisitoModel> requisitos);
    }
}
