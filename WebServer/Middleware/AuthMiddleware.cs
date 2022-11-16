using DataLayer.IDataService;

namespace WebServer.Middleware
{

    public static class AuthMiddlewareExt
    {
        public static void UseAuth(this WebApplication app)
        {
            app.UseMiddleware<AuthMiddleware>();
        }
    }
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserDataService _userDataService;

        public AuthMiddleware(RequestDelegate next, IUserDataService userDataService)
        {
            _next = next;
            _userDataService = userDataService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var username = context.Request.Headers.Authorization.FirstOrDefault();
            if (username != null)
            {
                var user = _userDataService.GetUsers(username);
                if (user != null)
                {
                context.Items["User"] = user;
                }
            }
            await _next(context);
        }
    }
}
