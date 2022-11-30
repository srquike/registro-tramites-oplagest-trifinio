using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task Create(UsuarioModel usuario);
        Task Delete(string usuarioId);
        Task Update(UsuarioModel usuario);
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuario(string usuarioId);
    }
}
