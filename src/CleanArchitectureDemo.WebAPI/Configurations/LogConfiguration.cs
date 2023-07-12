using Serilog;

namespace CleanArchitectureDemo.WebAPI.Configurations;

public static class LogConfiguration
{
    public static void AddLog(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        //var logPath = "./log/log-.txt";

        //var logger = new LoggerConfiguration()
        //    .WriteTo.Console()
        //    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        
        builder.Logging.AddSerilog(logger);
    }
}
