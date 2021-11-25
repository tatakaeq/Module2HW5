using System.IO;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class WriterService : IWriterService
    {
        private StreamWriter _streamWriter;
        public void StartWriter(string fileName)
        {
            _streamWriter = new StreamWriter(fileName);
        }

        public void Log(string log)
        {
            _streamWriter.WriteLine(log);
        }

        public void EndWriter()
        {
            EndWriter(_streamWriter);
        }

        public void EndWriter(StreamWriter streamWriter)
        {
            streamWriter.Close();
        }
    }
}