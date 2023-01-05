using RegistroTramitesOplagestTrifinio.Shared.DTOs.Actividades;

namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class GenerarRegistroActividad : IGeneraRegistroActividad
    {
        private readonly IPeticionesHttp _http;
        private readonly IMostrarMensaje _mensaje;

        public GenerarRegistroActividad(IPeticionesHttp http, IMostrarMensaje mensaje)
        {
            _http = http;
            _mensaje = mensaje;
        }

        public async Task Generar(string usuario, string resumen)
        {
            var actividad = new ActividadDTO();
            actividad.Resumen = resumen;
            actividad.NombreUsuario = usuario;

            var peticion = await _http.Post("api/actividades", actividad);

            if (peticion.Error)
            {
                await _mensaje.Error("No fue posible registrar la actividad del usuario");
            }
        }
    }
}
