namespace unam.Services
{
    public interface IToken
    {
        (string accessToken, string refreshToken) GenerateToken(string username);
    }
}
