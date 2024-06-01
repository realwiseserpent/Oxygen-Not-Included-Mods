using System;
using Newtonsoft.Json;
using PeterHan.PLib;
using PeterHan.PLib.Options;

namespace SharlesPlants
{
    [Serializable]
    [RestartRequired]
    [ConfigFileAttribute("SharlesPlants.Settings.json", true)]
    public class Settings
    {
        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = JsonSerializer<Settings>.Deserialize();
                if (_instance == null)
                {
                    _instance = new Settings();
                    JsonSerializer<Settings>.Serialize(_instance);
                }
                return _instance;
            }
        }

        public static void PLib_Initalize()
        {
            _instance = POptions.ReadSettings<Settings>();
        }

        public Settings()
        {
            BaseSettings = new BasicSettings();
        }

        [JsonProperty]
        [Option("Additional Settings", category: "Additional Settings")]
        public BasicSettings BaseSettings { get; set; }

        [Serializable]
        public class BasicSettings
        {
            [JsonProperty]
            [Option("Seeds spawn", "Do you want to spawn buries seeds?")]
            public bool SeedsSpawn { get; set; }

            public BasicSettings()
            {
                SeedsSpawn = false;
            }
        }
    }
}
