using System.IO;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Module2HW5.Services
{
    public class ConfigService : IConfigService
    {
        public ConfigService()
        {
            Config = new Config();
            LoadConfig();
        }

        public Config Config { get; set; }
        public void LoadConfig()
        {
            var config = File.ReadAllText("config.json");
            Config = JsonConvert.DeserializeObject<Config>(config);

            if (Config.LogFilesCounter == 0)
            {
                Config.LogFilesCounter = 3;
                SaveConfig();
            }

            if (Config.FolderPath == null)
            {
                Config.FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                SaveConfig();
            }

            if (Config.CountOfLogs == 0)
            {
                Config.CountOfLogs = 100;
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config);
            File.WriteAllText("config.json", json);
        }
    }
}