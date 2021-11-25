using Module2HW5.Helper;

namespace Module2HW5.Services.Abstractions
{
    public interface ILoger
    {
        public void Log(LogType type, string message);
        public void LogError(string message);
        public void LogWarning(string message);
        public void LogInfo(string message);
    }
}