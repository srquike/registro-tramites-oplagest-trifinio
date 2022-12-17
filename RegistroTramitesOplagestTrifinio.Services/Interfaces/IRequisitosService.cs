using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IRequisitosService
    {
        Task<List<RequisitoModel>> GetRequisitos();
        Task<int> UpdateMany(List<RequisitoModel> requisitos);
    }
}
