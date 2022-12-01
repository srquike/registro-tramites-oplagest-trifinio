namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class MostrarMensaje : IMostrarMensaje
    {
        public Task Error(string mensaje)
        {
            return Task.FromResult(0);
        }
    }
}
