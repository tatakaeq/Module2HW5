using Module2HW5.Helper;

namespace Module2HW5.Services.Abstractions
{
    public interface IConfigService
    {
        Config Config { get; set; }
        void LoadConfig();
        void SaveConfig();
    }
}