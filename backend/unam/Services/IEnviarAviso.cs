namespace unam.Services
{
    public interface IEnviarAviso
    {
        Task EnviarAviso(string correoEstudiante, string cabecera, string mensaje);
    }
}
