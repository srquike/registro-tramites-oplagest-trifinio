using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IInstructivosService
    {
        Task<List<InstructivoModel>> GetInstructivos();
        Task<List<RequisitoModel>> ObtenerRequisitosPorInstructivoIdAsync(int instructivoId);
    }
}
