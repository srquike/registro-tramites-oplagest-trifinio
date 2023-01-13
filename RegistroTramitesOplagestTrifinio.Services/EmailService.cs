using MailKit.Net.Smtp;
using MimeKit;
using RegistroTramitesOplagestTrifinio.Services.Configurations;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _configuration;

        public EmailService()
        {
            _configuration = new EmailConfiguration
            {
                Host = "mail.asociaciontrifinio.org",
                Port = 465,
                UserName = "plataforma@asociaciontrifinio.org",
                Password = "$Trifini0#"
            };
        }

        public async Task Enviar(MimeMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_configuration.Host, _configuration.Port.Value, true);
                await smtpClient.AuthenticateAsync(_configuration.UserName, _configuration.Password);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}