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

        [JsonProperty]
        [Option("Additional Settings", category: "Additional Settings")]
        public BasicSettings BaseSettings { get; set; }

        public Settings()
        {
            BaseSettings = new BasicSettings();
        }

        [Serializable]
        public class BasicSettings
        {
            [JsonProperty]
            [Option("Extended Description", "Do you want to extend plant descriptions?")]
            public bool ExtendedDesc { get; set; }

            public BasicSettings()
            {
                ExtendedDesc = false;
            }
        }
    }
}
