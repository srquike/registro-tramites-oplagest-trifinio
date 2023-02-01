using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IPersonasService
    {
        Task<int> UpdateAsync(PersonaModel persona);
    }
}
