namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class HttpResponseWrapper<T>
    {
        public bool Error { get; set; }
        public T Respuesta { get; set; } = default!;
        public HttpResponseMessage Mensaje { get; set; }

        public HttpResponseWrapper(bool error, HttpResponseMessage mensaje)
        {
            Error = error;
            Mensaje = mensaje;
        }

        public HttpResponseWrapper(bool error, T respuesta, HttpResponseMessage mensaje)
        {
            Error = error;
            Respuesta = respuesta;
            Mensaje = mensaje;
        }
    }
}
