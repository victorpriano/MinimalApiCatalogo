using MinimalApiCatalogo.Models;

namespace MinimalApiCatalogo.Services;
    public interface ITokenService
    {
        string GerarToken(string key, string issue, string audience, UserModel user);
    }
