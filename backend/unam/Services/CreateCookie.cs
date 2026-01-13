namespace unam.Services
{
    public class CreateCookie : ICookie
    {
        private readonly IHttpContextAccessor _httpContext;

        public CreateCookie(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void GenerateCookie(string token)
        {
            var context = _httpContext.HttpContext;
            if (context == null)
            {
                return;
            }
            context.Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(3)
            });
        }
    }
}
