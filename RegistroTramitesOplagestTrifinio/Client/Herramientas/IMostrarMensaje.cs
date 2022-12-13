namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public interface IMostrarMensaje
    {
        Task Completado(string mensaje);
        Task Confirmar(string mensaje);
        Task Error(string mensaje);
    }
}
