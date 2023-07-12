using CleanArchitectureDemo.WebAPI.Middleware;

namespace CleanArchitectureDemo.WebAPI.Configurations;

public static class MiddlewareConfiguration
{
    public static void AddMiddleware(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
    }
}
