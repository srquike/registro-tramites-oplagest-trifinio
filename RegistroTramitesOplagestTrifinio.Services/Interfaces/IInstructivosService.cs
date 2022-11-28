using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IInstructivosService
    {
        Task Create(InstructivoModel instructivo);
        Task Delete(string instructivoId);
        Task Update(InstructivoModel instructivo);
        Task<List<InstructivoModel>> GetInstructivos();
        Task<InstructivoModel> GetInstructivo(string instructivoId);
    }
}
