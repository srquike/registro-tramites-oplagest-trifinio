using RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios;

namespace RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces
{
    public interface ISesionService
    {
        Task Ingresar(UsuarioTokenDTO token);
        Task Cerrar();
        Task TokenRenovatorManagement();
    }
}
