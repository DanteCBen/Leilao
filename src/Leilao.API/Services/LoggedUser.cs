using Leilao.API.Entities;
using Leilao.API.Repositories;

namespace Leilao.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }
    public User User()
    {
        var repository = new LeilaoDbContext();

        var token = TokenOnRequest();
        var decodedToken = FromBase64String(token);

        var user = repository.Users.First(user => user.Email.Equals(decodedToken));

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
