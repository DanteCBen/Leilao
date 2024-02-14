using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }
    public User User()
    {
        var token = TokenOnRequest();
        var decodedToken = FromBase64String(token);

        var user = _repository.GetUserByEmail(decodedToken);

        return user;
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString(); // Get the token from the request and transform it into a string

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64String)
    {
        var data = Convert.FromBase64String(base64String);
        var result = System.Text.Encoding.UTF8.GetString(data); // Transform an byte array into a string

        return result;
    }
}
