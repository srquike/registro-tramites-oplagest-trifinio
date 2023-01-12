using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
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
                From = "administracion@asociaciontrifinio.org",
                SmtpHost = "mail.asociaciontrifinio.org",
                Port = 465,
                UserName = "administracion@asociaciontrifinio.org",
                Password = "$Trifini0#"
            };
        }

        public async Task Enviar()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Jonathan Vanegas", _configuration.From));
            message.To.Add(new MailboxAddress("Enrique Coreas", "jonathanenriquevc1998@gmail.com"));
            message.Subject = "Correo electronico de prueba";
            message.Body = new TextPart(TextFormat.Text) { Text = "Contenido de prueba" };

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_configuration.SmtpHost, _configuration.Port.Value, true);
                await smtpClient.AuthenticateAsync(_configuration.UserName, _configuration.Password);

                await smtpClient.SendAsync(message);
            }
        }
    }
}