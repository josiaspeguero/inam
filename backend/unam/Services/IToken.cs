namespace unam.Services
{
    public interface IToken
    {
        (string accessToken, string refreshToken) GenerateCookie(string username);
    }
}
