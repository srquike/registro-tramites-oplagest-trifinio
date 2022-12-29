using Microsoft.JSInterop;

namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string value)
        {
            return await js.InvokeAsync<object>("localStorage.setItem", key, value);
        }

        public static async ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
        {
            return await js.InvokeAsync<string>("localStorage.getItem", key);
        }

        public static async ValueTask<object> RemoveFromLocalStorage(this IJSRuntime js, string key)
        {
            return await js.InvokeAsync<object>("localStorage.removeItem", key);
        }

        public static async ValueTask InicializarTimerInactivo<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("timerInactivo", dotNetObjectReference);
        }
    }
}
