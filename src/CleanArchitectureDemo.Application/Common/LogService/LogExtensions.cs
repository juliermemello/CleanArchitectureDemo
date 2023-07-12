using CleanArchitectureDemo.Domain.Enums;

namespace CleanArchitectureDemo.Application.Common.LogService;

public static class LogExtensions
{
    public static void GenerateErrorLog(this LogService log, string message, Exception ex)
    {
        log = LogService.Instance;
        log.LogType = LogType.Error;
        log.ErrorLog(message, ex);
    }

    public static void GenerateFatalLog(this LogService log, string message, Exception ex)
    {
        log = LogService.Instance;
        log.LogType = LogType.Fatal;
        log.FatalLog(message, ex);
    }

    public static void GenerateInfoLog(this LogService log, string message)
    {
        log = LogService.Instance;
        log.LogType = LogType.Info;
        log.InfoLog(message);
    }
}
