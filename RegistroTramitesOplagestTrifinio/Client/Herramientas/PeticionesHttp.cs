using System.Text;
using System.Text.Json;

namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class PeticionesHttp : IPeticionesHttp
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };


        public PeticionesHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<TResponse>> Get<TResponse>(string url)
        {
            var respuesta = await _httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await Deserializar<TResponse>(respuesta, _serializerOptions);

                return new HttpResponseWrapper<TResponse>(false, contenido, respuesta);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(true, respuesta);
            }
        }

        public async Task<HttpResponseWrapper<T>> Post<T>(string url, T contenido)
        {
            var contenidoSerializado = JsonSerializer.Serialize(contenido);
            var contenidoAEnviar = new StringContent(contenidoSerializado, Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync(url, contenidoAEnviar);

            return new HttpResponseWrapper<T>(!respuesta.IsSuccessStatusCode, respuesta);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T contenido)
        {
            var contenidoSerializado = JsonSerializer.Serialize(contenido);
            var contenidoCodificado = new StringContent(contenidoSerializado, Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync(url, contenidoCodificado);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenidoDeserializado = await Deserializar<TResponse>(respuesta, _serializerOptions);
                return new HttpResponseWrapper<TResponse>(false, contenidoDeserializado, respuesta);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(true, respuesta);
            }
        }

        private async Task<T> Deserializar<T>(HttpResponseMessage responseMessage, JsonSerializerOptions serializerOptions)
        {
            var respuesta = await responseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(respuesta, serializerOptions)!;
        }
    }
}
