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

        }
    }
}
