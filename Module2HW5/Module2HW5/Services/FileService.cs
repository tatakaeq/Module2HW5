using System;
using System.IO;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private IWriterService _writerService;
        private string _folderPath;

        public FileService(IWriterService writerService, IConfigService configService)
        {
            _writerService = writerService;
            ConfigService = configService;
            _folderPath = configService.Config.FolderPath;

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            DeleteOldLog();
            StartWriter();
        }

        public IConfigService ConfigService { get; set; }

        public void StartWriter()
        {
            StartWriter(NameOfLogFile());
        }

        public string NameOfLogFile()
        {
            return Path.Combine(ConfigService.Config.FolderPath, $"{DateTime.UtcNow:hh.mm.ss dd.MM.yyyy}.txt");
        }

        public void StartWriter(string fileName)
        {
            _writerService.StartWriter(fileName);
        }

        public void Log(string log)
        {
            _writerService.Log(log);
        }

        public void EndWriter()
        {
            EndWriter(_writerService);
        }

        public void EndWriter(IWriterService writerService)
        {
            writerService.EndWriter();
        }

        public void DeleteOldLog()
        {
            var directoryInfo = new DirectoryInfo(_folderPath);
            var fileInfo = directoryInfo.GetFiles("*.txt");
            var filesToDelete = fileInfo.Length - ConfigService.Config.LogFilesCounter;

            Array.Sort<FileInfo>(fileInfo, new LastModifiedFileCheck());
            for (var i = 0; i < filesToDelete; i++)
            {
                try
                {
                    File.Delete(fileInfo[i].FullName);
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}