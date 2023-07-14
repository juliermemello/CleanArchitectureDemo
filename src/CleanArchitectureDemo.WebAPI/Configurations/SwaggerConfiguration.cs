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

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = @"JWT Authorization header using the Bearer scheme.<br /><br />
                                Enter 'Bearer' [space] and then your token in the text input below.<br />
                                Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new string[]{}
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
