namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public interface IPeticionesHttp
    {
        Task<HttpResponseWrapper<T>> Delete<T>(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<T>> Post<T>(string url, T contenido);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T contenido);
        Task<HttpResponseWrapper<T>> Put<T>(string url, T contenido);
    }
}
