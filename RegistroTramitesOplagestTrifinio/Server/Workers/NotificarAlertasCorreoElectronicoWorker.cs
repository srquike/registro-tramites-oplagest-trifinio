using MimeKit;
using MimeKit.Text;
using RegistroTramitesOplagestTrifinio.Client.Pages.Tramites;
using RegistroTramitesOplagestTrifinio.Server.Herramientas;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using System.Text;

namespace RegistroTramitesOplagestTrifinio.Server.Workers
{
    public class NotificarAlertasCorreoElectronicoWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificarAlertasCorreoElectronicoWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (!stoppingToken.IsCancellationRequested)
                {
                    using (var alertasScope = _serviceProvider.CreateScope())
                    {
                        var alertasScopeProcessingService = alertasScope.ServiceProvider.GetRequiredService<IAlertas>();

                        AlertasDTO alertas = await alertasScopeProcessingService.ObtenerAlertas();
                        var message = new MimeMessage();
                        var contenido = new StringBuilder();
                        var to = new List<MailboxAddress>
                        {
                            new MailboxAddress("Jonathan Vanegas", "jonathan.vanegas@catolica.edu.sv"),
                            new MailboxAddress("Brayan Rivas", "brayan.rivas@catolica.edu.sv")
                        };

                        message.Subject = "Notificaciones y alertas";
                        message.From.Add(new MailboxAddress("Plataforma OPLAGEST-Trifinio", "plataforma@asociaciontrifinio.org"));
                        message.To.AddRange(to);

                        var cantidadNotificaciones = alertas.TramitesPorAgendar.Count + alertas.TramitesPorVisitar.Count + alertas.TramitesPorFirmar.Count;

                        var cantidadAlertas = alertas.TramitesSinAgendar.Count + alertas.TramitesSinVisitar.Count + alertas.TramitesSinFirmar.Count;

                        contenido.Append("<html>");

                        if (cantidadNotificaciones is not 0)
                        {
                            contenido.Append("<h2>Notificaciones</h2>");

                            if (alertas.TramitesPorAgendar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesPorAgendar.Count} trámites que deben ser agendados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesPorAgendar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                            
                            if (alertas.TramitesPorVisitar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesPorVisitar.Count} trámites que deben ser visitados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesPorVisitar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                            
                            if (alertas.TramitesPorVisitar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesPorFirmar.Count} trámites que deben ser firmados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesPorFirmar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                        }
                        
                        if (cantidadAlertas is not 0)
                        {
                            contenido.Append("<h2>Alertas</h2>");

                            if (alertas.TramitesSinAgendar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesSinAgendar.Count} trámites que no fuerón agendados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesSinAgendar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                            
                            if (alertas.TramitesSinVisitar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesSinVisitar.Count} trámites que no fuerón visitados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesSinVisitar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                            
                            if (alertas.TramitesSinFirmar.Count is not 0)
                            {
                                contenido.Append($"<h3>Hay {alertas.TramitesSinFirmar.Count} trámites que no fuerón firmados.</h3>");
                                contenido.Append("<ul>");
                                alertas.TramitesSinFirmar.ForEach(t => contenido.Append($"<li>Expediente: {t.Expediente}</li>"));
                                contenido.Append("</ul>");
                            }
                        }

                        contenido.Append("</html>");

                        message.Body = new TextPart(TextFormat.Html)
                        {
                            Text = string.Format(contenido.ToString())
                        };

                        using (var emailScope = _serviceProvider.CreateScope())
                        {
                            var emailScopeProcessingService = alertasScope.ServiceProvider.GetRequiredService<IEmailService>();

                            await emailScopeProcessingService.Enviar(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
