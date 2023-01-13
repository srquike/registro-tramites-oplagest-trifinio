using MimeKit;
using System.Net.Mail;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IEmailService
    {
        Task Enviar(MimeMessage message);
    }
}
