namespace CleanArchitectureDemo.WebAPI.Configurations
{
    public static class CorsConfiguration
    {
        private static string CorsPolicy = "localhost-policy";

        public static void AddAPICors(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void AddAPICors(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseCors(CorsPolicy);
        }
    }
}
