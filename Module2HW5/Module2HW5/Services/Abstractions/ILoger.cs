using Module2HW5.Helper;

namespace Module2HW5.Services.Abstractions
{
    public interface ILoger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void Log(LogType logType, string message);
        void End();
    }
}