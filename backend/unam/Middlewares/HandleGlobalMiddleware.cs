using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace unam.Middlewares
{
    public class HandleGlobalMiddleware
    {
        private readonly ILogger<HandleGlobalMiddleware> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly RequestDelegate _next;

        public HandleGlobalMiddleware(ILogger<HandleGlobalMiddleware> logger,
            IWebHostEnvironment env,
            RequestDelegate next)
        {
            _logger = logger;
            _env = env;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                await handleError(context, ex);
            }
        }

        public Task handleError(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var mensaje = JsonSerializer.Serialize(new
            {
                mensaje = _env.IsProduction() ? "Ha ocurrido un error" : ex.Message
            });

            return context.Response.WriteAsync(mensaje);
        }
    }
}
