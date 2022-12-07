using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<int> Create(UsuarioModel usuario);
        Task<int> Delete(string usuarioId);
        Task<int> Update(UsuarioModel usuario);
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuario(string usuarioId);
    }
}
