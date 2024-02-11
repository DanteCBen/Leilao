using Leilao.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leilao.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var repository = new LeilaoDbContext();

            var decodedEmail = FromBase64String(token);

            var exist = repository.Users.Any(user => user.Email.Equals(decodedEmail));

            if (!exist)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString(); // Get the token from the request and transform it into a string

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing");
        }

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64String)
    {
        var data = Convert.FromBase64String(base64String);
        var result = System.Text.Encoding.UTF8.GetString(data); // Transform an byte array into a string

        return result;
    }
}
