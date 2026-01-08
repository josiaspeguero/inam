namespace unam.Services
{
    public interface IEnviarMensaje
    {
        Task EnviarAviso(string correoEstudiante, string cabecera, string mensaje);
    }
}
