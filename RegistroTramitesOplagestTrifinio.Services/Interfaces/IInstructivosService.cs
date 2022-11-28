using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    internal interface IInstructivosService
    {
        void Create(InstructivoModel instructivo);
        void Delete(int instructivoId);
        void Update(InstructivoModel instructivo);
        List<InstructivoModel> GetInstructivos();
        InstructivoModel GetInstructivo(int instructivoId);
    }
}
