namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public interface IMostrarMensaje
    {
        Task Completado(string mensaje);
        Task<bool> Confirmar(string mensaje);
        Task Error(string mensaje);
        Task<bool> Notificar(string mensaje);
    }
}