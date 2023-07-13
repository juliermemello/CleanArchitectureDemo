using Microsoft.OpenApi.Models;

namespace CleanArchitectureDemo.WebAPI.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Clean Architecture Demo",
                Description = "Project for study and demonstration of Clean Architecture.",
                Contact = new OpenApiContact
                {
                    Name = "Julierme Pereira Mello",
                    Email = "juliermemello@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://github.com/juliermemello/CleanArchitectureDemo/blob/master/LICENSE")
                }
            });
        });
    }

    public static void AddSwagger(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();

        app.UseSwaggerUI(s =>
        {
            s.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture Demo API v1");
        });
    }
}
