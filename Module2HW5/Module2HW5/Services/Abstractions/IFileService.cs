namespace Module2HW5.Services.Abstractions
{
    public interface IFileService
    {
        void Log(string log);
        void StartWriter();
        void StartWriter(string fileName);
        string NameOfLogFile();
        void EndWriter();
        void EndWriter(IWriterService writerService);
        void DeleteOldLog();
    }
}