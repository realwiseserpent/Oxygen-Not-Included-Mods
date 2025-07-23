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
        [Option("Low Decor", category: "1. Low Decor Settings")]
        public BasicDecorSettings LowDecor { get; set; }

        [JsonProperty]
        [Option("Standard Decor", category: "2. Standard Decor Settings")]
        public BasicDecorSettings StandardDecor { get; set; }

        [JsonProperty]
        [Option("Medium Decor", category: "3. Medium Decor Settings")]
        public BasicDecorSettings MediumDecor { get; set; }

        [JsonProperty]
        [Option("High Decor", category: "4. High Decor Settings")]
        public BasicDecorSettings HighDecor { get; set; }

        [JsonProperty]
        [Option("Amazing Decor", category: "5. Amazing Decor Settings")]
        public BasicDecorSettings AmazingDecor { get; set; }

        [JsonProperty]
        [Option("Additional Settings", category: "0. Additional Settings")]
        public BasicSettings BaseSettings { get; set; }

        public Settings()
        {
            LowDecor = new BasicDecorSettings() { Amount = 10, Radius = 3 };
            StandardDecor = new BasicDecorSettings() { Amount = 20, Radius = 3 };
            MediumDecor = new BasicDecorSettings() { Amount = 30, Radius = 4 };
            HighDecor = new BasicDecorSettings() { Amount = 40, Radius = 5 };
            AmazingDecor = new BasicDecorSettings() { Amount = 50, Radius = 6 };

            BaseSettings = new BasicSettings();
        }

        public EffectorValues GetEffectorValues(DecorType ed)
        {
            switch (ed)
            {
                case DecorType.LowDecor: return new EffectorValues(LowDecor.Amount, LowDecor.Radius);
                case DecorType.StandardDecor: return new EffectorValues(StandardDecor.Amount, StandardDecor.Radius);
                case DecorType.MediumDecor: return new EffectorValues(MediumDecor.Amount, MediumDecor.Radius);
                case DecorType.HighDecor: return new EffectorValues(HighDecor.Amount, HighDecor.Radius);
                case DecorType.AmazingDecor: return new EffectorValues(AmazingDecor.Amount, AmazingDecor.Radius);
                default: return TUNING.DECOR.BONUS.TIER0;
            };
        }

        [Serializable]
        public class BasicDecorSettings
        {
            [JsonProperty]
            [Limit(1, 100)]
            [Option("Decor Amount", "Select amount of decor")]
            public int Amount { get; set; }

            [JsonProperty]
            [Limit(1, 10)]
            [Option("Decor Radius", "Select radius of decor")]
            public int Radius { get; set; }

            public BasicDecorSettings()
            {
                Amount = 10;
                Radius = 3;
            }
        }

        [Serializable]
        public class BasicSettings
        {
            [JsonProperty]
            [Option("Spawn of buried seeds", "Do you want to spawn buried seeds?")]
            public bool SeedsSpawn { get; set; }

            [JsonProperty]
            [Option("Detailed description (Codex)", "Would you like to get a detailed description of plants?")]
            public bool ExtendedDesc { get; set; }

            [JsonProperty]
            [Option("Spore Lamp reactive gases", "Would you like to expand the list of Spore Lamp reactive gases?")]
            public bool ExtendedSporeLampGasList { get; set; }

            public BasicSettings()
            {
                SeedsSpawn = true;
                ExtendedDesc = true;
                ExtendedSporeLampGasList = false;
            }
        }
    }
}
