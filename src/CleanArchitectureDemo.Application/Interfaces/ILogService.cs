using CleanArchitectureDemo.Domain.Enums;

namespace CleanArchitectureDemo.Application.Interfaces;

internal interface ILogService
{
    string LogMessage { get; set; }
    LogType LogType { get; set; }

    void InfoLog(string message);
    void ErrorLog(string message, Exception ex);
}
