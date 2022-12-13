using CurrieTechnologies.Razor.SweetAlert2;

namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class MostrarMensajes : IMostrarMensaje
    {
        private readonly SweetAlertService _sweetAlert;

        public MostrarMensajes(SweetAlertService sweetAlert)
        {
            _sweetAlert = sweetAlert;
        }

        public async Task Error(string mensaje)
        {
            await MostrarMensaje("Ocurrio un error al intentar realizar la tarea.", mensaje, SweetAlertIcon.Error, false);
        }
        
        public async Task Completado(string mensaje)
        {
            await MostrarMensaje("¡Tarea completada!", mensaje, SweetAlertIcon.Success, false);
        }
        
        public async Task Confirmar(string mensaje)
        {
            await MostrarMensaje("¿Desea continuar?", mensaje, SweetAlertIcon.Question, false);
        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, SweetAlertIcon icono, bool cancelar)
        {
            await _sweetAlert.FireAsync(new SweetAlertOptions
            {
                Title = titulo,
                Text = mensaje,
                Icon = icono,
                ShowCancelButton = cancelar
            });
        }
    }
}
