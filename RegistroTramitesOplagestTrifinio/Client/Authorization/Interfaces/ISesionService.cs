namespace RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces
{
    public interface ISesionService
    {
        Task Ingresar(string token);
        Task Cerrar();
    }
}
