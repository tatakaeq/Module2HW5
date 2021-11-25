using System;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class Loger : ILoger
    {
        private readonly IFileService _fileService;
        private readonly IConfigService _configService;
        private readonly LogerConfig _logerConfig;

        public Loger(IConfigService configService, IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _logerConfig = _configService.Config.LogerConfig;
            FileServiceInit();
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
            var log = $"{DateTime.UtcNow.ToString(_logerConfig.TimeFormat)}: {logType.ToString()}: {message}";
            _fileService.Log(log);
            Console.WriteLine(log);
        }

        public void FileServiceInit()
        {
            var fileName = DateTime.UtcNow.ToString(_logerConfig.NameFormat);
            var fileExtension = _logerConfig.FileExtension;
            var filePath = _logerConfig.FilePath;
            var count = _logerConfig.DirectoryCount;
            _fileService.Init(fileName, fileExtension, filePath, count);
        }
    }
}