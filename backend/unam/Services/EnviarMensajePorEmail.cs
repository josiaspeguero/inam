
using System.Net;
using System.Net.Mail;

namespace unam.Services
{
    public class EnviarMensajePorEmail : IEnviarAviso
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
                var usuarioAdmin = _configuration.GetValue<string>("usuario: admin");
                var credenciales = _configuration.GetValue<string>("usuario:credentials");
                var host = _configuration.GetValue<string>("usuario:host");
                var port = _configuration.GetValue<int>("usuario:port");

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
