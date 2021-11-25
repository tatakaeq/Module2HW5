using System;
using System.IO;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private StreamWriter _streamWriter;
        private DirectoryInfo _directoryInfo;
        private int _directoryCount;

        public void Log(string log)
        {
            _streamWriter.WriteLine(log);
        }

        public void Init(string fileName, string fileExtension, string filePath, int count)
        {
            _directoryCount = count;
            DirectoryInit(filePath);
            _streamWriter = new StreamWriter($"{filePath}{fileName}{fileExtension}", true);
        }

        public void DirectoryInit(string filePath)
        {
            _directoryInfo = new DirectoryInfo(filePath);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
            else
            {
                DeleteOldLog(_directoryCount);
            }
        }

        private void DeleteOldLog(int max)
        {
            var files = _directoryInfo.GetFiles();

            if (files.Length >= max)
            {
                Array.Sort(files, new LastModifiedFileCheck());

                for (var i = 0; i < files.Length - (max - 1); i++)
                {
                    files[i].Delete();
                }
            }
        }
    }
}