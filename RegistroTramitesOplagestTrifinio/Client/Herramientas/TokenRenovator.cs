using RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces;
using Timer = System.Timers.Timer;
using ElapsedEventArgs = System.Timers.ElapsedEventArgs;

namespace RegistroTramitesOplagestTrifinio.Client.Herramientas
{
    public class TokenRenovator : IDisposable
    {
        private readonly ISesionService _sesionService;
        private Timer _timer;

        public TokenRenovator(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public void Iniciar()
        {
            _timer = new Timer
            {
                Interval = 10000 * 6 * 4 // 4 minutos
            };

            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _sesionService.TokenRenovatorManagement();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}