using System.IO;

namespace Module2HW5.Services.Abstractions
{
    public interface IWriterService
    {
        void StartWriter(string fileName);
        void Log(string log);
        void EndWriter();
        void EndWriter(StreamWriter streamWriter);
    }
}