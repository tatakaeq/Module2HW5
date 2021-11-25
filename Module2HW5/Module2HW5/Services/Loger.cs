using System;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class Loger : ILoger
    {
        private readonly IFileService _fileService;

        public Loger(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow}: {logType.ToString()}: {message}";
            _fileService.Log(log);

            Console.WriteLine(log);
        }

        public void End()
        {
            _fileService.EndWriter();
        }
    }
}