using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restful_Api.Services;

namespace Restful_Api.Attributes;

public class AuthorizeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userService = context.HttpContext.RequestServices.GetService<IUserService>();
        var username = context.HttpContext.Request.Headers["Username"].ToString();
        var password = context.HttpContext.Request.Headers["Password"].ToString();

        if (!userService.Authenticate(username, password))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}