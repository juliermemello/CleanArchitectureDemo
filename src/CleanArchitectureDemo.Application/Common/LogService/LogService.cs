using CleanArchitectureDemo.Application.Interfaces;
using CleanArchitectureDemo.Domain.Enums;
using log4net;
using System.Security;

namespace CleanArchitectureDemo.Application.Common.LogService;

public class LogService : ILogService
{
    private readonly ILog _logger;
    private static LogService _instance;

    public string LogPath { get; }
    public string LogMessage { get; set; }
    public LogType LogType { get; set; }

    public static LogService Instance
    {
        get
        {
            return _instance ?? new LogService(LogType.Info);
        }
    }

    public LogService(LogType logType)
    {
        LogType = logType;

        _logger = LogType switch
        {
            LogType.Info => LogManager.GetLogger("InfoLogger"),
            LogType.Error => LogManager.GetLogger("ErrorLogger"),
            LogType.Fatal => LogManager.GetLogger("FatalLogger"),
            _ => throw new ArgumentOutOfRangeException(nameof(logType))
        };

        LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyApp", "Logs");
    }

    private static bool IsFatalException(Exception ex)
    {
        return ex is SystemException ||
               ex is InvalidOperationException ||
               ex is SecurityException ||
               ex is OutOfMemoryException ||
               ex is StackOverflowException ||
               ex is AccessViolationException ||
               ex is DivideByZeroException ||
               ex is NullReferenceException;
    }

    public void InfoLog(string message)
    {
        if (LogType is LogType.Info)
            _logger.Info(message);
    }

    public void FatalLog(string message, Exception ex)
    {
        if (LogType is LogType.Fatal && IsFatalException(ex))
            _logger.Fatal(message, ex);
    }

    public void ErrorLog(string message, Exception ex)
    {
        if (LogType is LogType.Error)
            _logger.Error(message, ex);
    }
}
