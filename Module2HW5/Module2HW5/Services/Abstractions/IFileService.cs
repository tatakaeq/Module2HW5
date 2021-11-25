namespace Module2HW5.Services.Abstractions
{
    public interface IFileService
    {
        public void Init(string fileName, string fileExtension, string filePath, int count);
        public void Log(string text);
    }
}