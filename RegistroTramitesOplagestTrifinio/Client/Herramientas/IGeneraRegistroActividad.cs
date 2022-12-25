namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public interface IGeneraRegistroActividad
    {
        Task Generar(string usuario, string resumen);
    }
}
