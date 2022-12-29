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
            var resultado = await MostrarMensaje("¡Tarea completada!", mensaje, SweetAlertIcon.Success, false);
        }
        
        public async Task<bool> Confirmar(string mensaje)
        {
            var resultado = await MostrarMensaje("¿Desea continuar?", mensaje, SweetAlertIcon.Question, true);

            return resultado.IsConfirmed;
        }

        private async Task<SweetAlertResult> MostrarMensaje(string titulo, string mensaje, SweetAlertIcon icono, bool cancelar)
        {
            return await _sweetAlert.FireAsync(new SweetAlertOptions
            {
                Title = titulo,
                Text = mensaje,
                Icon = icono,
                ShowCancelButton = cancelar,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar",
                AllowOutsideClick = false,
                AllowEscapeKey = false,
                AllowEnterKey = false
            });
        }

        public async Task<bool> Notificar(string mensaje)
        {
            var resultado = await MostrarMensaje("Notificación", mensaje, SweetAlertIcon.Info, false);

            return resultado.IsConfirmed;
        }
    }
}
