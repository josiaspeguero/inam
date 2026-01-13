
using System.Net;
using System.Net.Mail;

namespace unam.Services
{
    public class EnviarMensajePorEmail : IEnviarMensaje
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EnviarMensajePorEmail> _logger;

        public EnviarMensajePorEmail(IConfiguration configuration, ILogger<EnviarMensajePorEmail> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task EnviarAviso(string correoEstudiante, string cabecera, string mensaje)
        {
            try
            {
                var usuarioAdmin = _configuration.GetValue<string>("SMTP_CLIENT: USER");
                var credenciales = _configuration.GetValue<string>("SMTP_CLIENT:PASSWORD");
                var host = _configuration.GetValue<string>("SMTP_CLIENT:HOST");
                var port = _configuration.GetValue<int>("SMTP_CLIENT:PORT");

                using (var smtpClient = new SmtpClient(host, port))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(usuarioAdmin, credenciales);
                    smtpClient.EnableSsl = true;

                    using (var mensajeEnvio = new MailMessage(usuarioAdmin!, correoEstudiante, cabecera, mensaje))
                    {
                        await smtpClient.SendMailAsync(mensajeEnvio);
                    }
                }

            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al enviar el mensaje");
            }
        }
    }
}
