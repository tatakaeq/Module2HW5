using System.IO;
using Module2HW5.Helper;
using Module2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Module2HW5.Services
{
    public class ConfigService : IConfigService
    {
        private const string Path = "config.json";
        private Config _config;
        public ConfigService()
        {
            ConfigInit();
        }

        public Config Config => _config;

        private void ConfigInit()
        {
            var text = File.ReadAllText(Path);
            _config = JsonConvert.DeserializeObject<Config>(text);
        }
    }
}