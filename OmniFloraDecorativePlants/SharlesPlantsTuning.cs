using ProcGen;
using System.Collections.Generic;
using System.Linq;
using Temperatures = ProcGen.Temperature.Range;

namespace SharlesPlants
{
    public class SharlesPlantsTuning
    {
        public static bool DebugMode = false;
        public static string[] SupportedVersions = DlcManager.AVAILABLE_ALL_VERSIONS;

        public class BIOME_STRINGS
        {
            public static string PREFIX = "biomes" + "/"; // System.IO.Path.DirectorySeparatorChar; // KLEI delimiter char? might be OS dependent
            public static string BARREN = "Barren",
                DEFAULT = PREFIX + "Default",
                FOREST = PREFIX + "Forest",
                FROZEN = PREFIX + "Frozen",
                MARSH = PREFIX + "HotMarsh",
                JUNGLE = PREFIX + "Jungle",
                MAGMA = PREFIX + "Magma",
                MISC = PREFIX + "Misc",
                EMPTY = PREFIX + "Misc/Empty",
                OCEAN = PREFIX + "Ocean",
                OIL = PREFIX + "Oil",
                RUST = PREFIX + "Rust",
                SEDIMENTARY = PREFIX + "Sedimentary",
                AQUATIC = PREFIX + "Aquatic",
                METALLIC = PREFIX + "Metallic",
                MOO = PREFIX + "Moo",
                NIOBIUM = PREFIX + "Niobium",
                RADIOACTIVE = PREFIX + "Radioactive",
                SWAMP = PREFIX + "Swamp",
                WASTELAND = PREFIX + "Wasteland";
        }
        public class EARTH_BIOME_STRINGS //Earth mod
        {
            public static string PREFIX = @"biomes/Earth/";
            public static string
                ASTHENOSPHERE = PREFIX + "Asthenosphere",
                CORE = PREFIX + "Core",
                MANTLE = PREFIX + "Mantle",
                MANTLE2 = PREFIX + "Mantle2",
                OCEAN = PREFIX + "Ocean",
                SKY = PREFIX + "Sky",
                SURFACE = PREFIX + "Surface";
        }
        public class BAATOR_BIOME_STRINGS //Baator mod
        {
            public static string PREFIX = @"biomes/";
            public static string
                SURFACECRAGS = PREFIX + "Baator_SurfaceCrags",
                SHADOWFEL = PREFIX + "Baator_Shadowfel",
                AVERNUS = PREFIX + "Baator_Avernus",
                DIS = PREFIX + "Baator_Dis",
                MINAUROS = PREFIX + "Baator_Minauros",
                PHLEGETHOS = PREFIX + "Baator_Phlegethos",
                STYGIA = PREFIX + "Baator_Stygia",
                MALBOLGE = PREFIX + "Baator_Malbolge",
                MALADOMINI = PREFIX + "Baator_Maladomini",
                CANIA = PREFIX + "Baator_Cania",
                NESSUS = PREFIX + "Baator_Nessus";
        }
        public class EMPTY_WORLDS_BIOME_STRINGS //EmptyWorlds mod
        {
            public static string CUSTOMFOREST = "CustomForest";
        }

        public static EffectorValues WiltDecor = TUNING.DECOR.PENALTY.TIER3;
        public static EffectorValues LowDecor = new EffectorValues() { amount = 10, radius = 3 };
        public static EffectorValues StandardDecor = new EffectorValues() { amount = 20, radius = 3 };
        public static EffectorValues MediumDecor = new EffectorValues() { amount = 40, radius = 5 };
        public static EffectorValues HighDecor = new EffectorValues() { amount = 70, radius = 6 };
        public static EffectorValues AmazingDecor = new EffectorValues() { amount = 100, radius = 7 };

        public static MinMax seedDensity = new MinMax(0.005f, 0.01f);

        // Prickly Lotus tuning
        public static PlantTuning PricklyLotusTuning = new PlantTuning
        {
            density = new MinMax(0.08f, 0.14f),
            lethalLow = 263.15f,            // -10C
            warningLow = 283.15f,           //  10C
            transitionLow = 303.15f,        //  30C
            transitionHigh = 323.15f,       //  50C
            warningHigh = 363.15f,          //  90C
            lethalhigh = 403.15f,           // 130C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
                Temperatures.Hot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.JUNGLE,
                BIOME_STRINGS.OIL,
                BIOME_STRINGS.MOO,
                BIOME_STRINGS.WASTELAND,
                "Desert", //SEDIMENTARY desert + TestDesert from RollerSnake
                BAATOR_BIOME_STRINGS.NESSUS,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning PricklyLotusSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = new HashSet<string>(PricklyLotusTuning.biomes) {
                BAATOR_BIOME_STRINGS.MALADOMINI,
                BAATOR_BIOME_STRINGS.MALBOLGE,
            },
            biomesExcluded = new HashSet<string>() {
                BIOME_STRINGS.MOO,
                BAATOR_BIOME_STRINGS.NESSUS
            },
        };

        // Frost Blossom tuning
        public static PlantTuning FrostBlossomTuning = new PlantTuning
        {
            density = new MinMax(0.15f, 0.25f),
            lethalLow = 173.15f,            // -100C
            warningLow = 213.15f,           // -60C
            transitionLow = 253.15f,        // -20C
            transitionHigh = 273.15f,       //   0C
            warningHigh = 283.15f,          //  10C
            lethalhigh = 303.15f,           //  30C
            defaultTemperature = 275.15f,   //   2C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Vacuum,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.VeryCold,
                Temperatures.Cold,
                Temperatures.Chilly,
                Temperatures.Cool,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.FROZEN,
                BIOME_STRINGS.RADIOACTIVE,
                BAATOR_BIOME_STRINGS.STYGIA,
                BAATOR_BIOME_STRINGS.CANIA,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning FrostBlossomSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = FrostBlossomTuning.biomes,
            biomesExcluded = new HashSet<string>() {
                BAATOR_BIOME_STRINGS.STYGIA
            }
        };

        // Icy Shroom tuning
        public static PlantTuning IcyShroomTuning = new PlantTuning
        {
            density = new MinMax(0.12f, 0.20f),
            lethalLow = 193.15f,            // -80C
            warningLow = 233.15f,           // -40C
            transitionLow = 268.15f,        //  -5C
            transitionHigh = 281.15f,       //   8C
            warningHigh = 291.15f,          //  18C
            lethalhigh = 303.15f,           //  30C
            defaultTemperature = 283.15f,   //  10C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Vacuum,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Cold,
                Temperatures.Chilly,
                Temperatures.Cool,
                Temperatures.Mild,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.SEDIMENTARY,
                BIOME_STRINGS.FOREST,
                BIOME_STRINGS.FROZEN,
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.OCEAN,
                BIOME_STRINGS.SWAMP,
                BAATOR_BIOME_STRINGS.STYGIA,
                BAATOR_BIOME_STRINGS.CANIA,
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                EARTH_BIOME_STRINGS.SURFACE,
                EMPTY_WORLDS_BIOME_STRINGS.CUSTOMFOREST,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning IcyShroomSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = new HashSet<string>() {
                BIOME_STRINGS.FROZEN,
                BAATOR_BIOME_STRINGS.CANIA,
            },
        };

        // Myrth Rose tuning
        public static PlantTuning MyrthRoseTuning = new PlantTuning
        {
            density = new MinMax(0.08f, 0.12f),
            lethalLow = 273.15f,            //   0C
            warningLow = 288.15f,           //  15C
            transitionLow = 295.15f,        //  22C
            transitionHigh = 309.15f,       //  36C
            warningHigh = 328.15f,          //  55C
            lethalhigh = 363.15f,           //  90C
            defaultTemperature = 293.15f,   //  20C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
                Temperatures.Hot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.SEDIMENTARY,
                BIOME_STRINGS.FOREST,
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.JUNGLE,
                BIOME_STRINGS.SWAMP,
                BIOME_STRINGS.WASTELAND,
                "Desert", //SEDIMENTARY desert + TestDesert from RollerSnake
                BAATOR_BIOME_STRINGS.NESSUS,
                BAATOR_BIOME_STRINGS.DIS,
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                EARTH_BIOME_STRINGS.SURFACE,
                EMPTY_WORLDS_BIOME_STRINGS.CUSTOMFOREST,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning MyrthRoseSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = new HashSet<string>() {
                BIOME_STRINGS.JUNGLE,
                "Desert",
                BIOME_STRINGS.WASTELAND,
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                BAATOR_BIOME_STRINGS.NESSUS,
                BAATOR_BIOME_STRINGS.DIS,
            },
        };

        // Rust Fern tuning
        public static PlantTuning RustFernTuning = new PlantTuning
        {
            density = new MinMax(0.13f, 0.20f),
            lethalLow = 223.15f,            // -50C
            warningLow = 258.15f,           // -15C
            transitionLow = 307.15f,        //  34C
            transitionHigh = 321.15f,       //  48C
            warningHigh = 335.15f,          //  62C
            lethalhigh = 353.15f,           //  80C
            defaultTemperature = 308.15f,   //  35C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Chilly,
                Temperatures.Cool,
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.RUST,
                BIOME_STRINGS.OCEAN,
                BIOME_STRINGS.BARREN,
                BIOME_STRINGS.RADIOACTIVE,
                BIOME_STRINGS.WASTELAND,
                "GraphiteCaves",
                BAATOR_BIOME_STRINGS.SHADOWFEL,
                BAATOR_BIOME_STRINGS.STYGIA,
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                EARTH_BIOME_STRINGS.SURFACE,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning RustFernSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = new HashSet<string>() {
                BIOME_STRINGS.RUST,
                BIOME_STRINGS.BARREN,
                "GraphiteCaves",
                EARTH_BIOME_STRINGS.SURFACE,
                BAATOR_BIOME_STRINGS.SHADOWFEL,
            },
        };

        // Spore Lamp tuning
        public static PlantTuning SporeLampTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 263.15f,            // -10C
            warningLow = 278.15f,           //   5C
            transitionTemp = 301.15f,       //  28C
            warningHigh = 361.15f,          //  88C
            lethalhigh = 403.15f,           // 130C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Methane,
                SimHashes.SourGas,
                SimHashes.Hydrogen,
                SimHashes.EthanolGas,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
                Temperatures.Hot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.SWAMP,
                BIOME_STRINGS.MOO,
                BAATOR_BIOME_STRINGS.AVERNUS,
                EARTH_BIOME_STRINGS.MANTLE,
            },
            spawnLocation = Mob.Location.Floor,
        };

        public static SeedTuning SporeLampSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = SporeLampTuning.biomes,
            biomesExcluded = new HashSet<string>() {
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.MOO,
                EARTH_BIOME_STRINGS.MANTLE2,
            },
        };

        // Tropicalgae tuning
        public static PlantTuning TropicalgaeTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 253.15f,            // -20C
            warningLow = 283.15f,           //  10C
            transitionTemp = 303.15f,       //  30C
            warningHigh = 328.15f,          //  55C
            lethalhigh = 353.15f,           //  80C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = LowDecor,
            matureDecor = StandardDecor,
            flourishingDecor = MediumDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Water,
                SimHashes.DirtyWater,
                SimHashes.SaltWater,
                SimHashes.Brine,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Cool,
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
                Temperatures.Hot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.SEDIMENTARY,
                BIOME_STRINGS.FOREST,
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.OCEAN,
                BIOME_STRINGS.AQUATIC,
                BIOME_STRINGS.SWAMP,
                BIOME_STRINGS.WASTELAND,
                BAATOR_BIOME_STRINGS.MINAUROS,
                BAATOR_BIOME_STRINGS.AVERNUS,
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                EARTH_BIOME_STRINGS.SURFACE,
                EARTH_BIOME_STRINGS.OCEAN,
                EMPTY_WORLDS_BIOME_STRINGS.CUSTOMFOREST,
            },
            spawnLocation = Mob.Location.LiquidFloor,
        };

        public static SeedTuning TropicalgaeSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = new HashSet<string>() {
                BIOME_STRINGS.MARSH,
                BIOME_STRINGS.AQUATIC,
                BAATOR_BIOME_STRINGS.MINAUROS,
                EARTH_BIOME_STRINGS.OCEAN,
            },
        };

        // Shlurp Coral tuning
        public static PlantTuning ShlurpCoralTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 253.15f,            // -20C
            warningLow = 288.15f,           //  15C
            transitionTemp = 305.15f,       //  32C
            warningHigh = 322.15f,          //  49C
            lethalhigh = 348.15f,           //  75C
            defaultTemperature = 303.15f,   //  30C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Water,
                SimHashes.DirtyWater,
                SimHashes.SaltWater,
                SimHashes.Brine,
            },
            biomeTemperatures = new HashSet<Temperatures>()
            {
                Temperatures.Cool,
                Temperatures.Mild,
                Temperatures.Room,
                Temperatures.HumanWarm,
                Temperatures.HumanHot,
                Temperatures.Hot,
            },
            biomes = new HashSet<string>()
            {
                BIOME_STRINGS.OCEAN,
                BIOME_STRINGS.AQUATIC,
                BAATOR_BIOME_STRINGS.MINAUROS,
                BAATOR_BIOME_STRINGS.STYGIA,
                BAATOR_BIOME_STRINGS.AVERNUS,
                EARTH_BIOME_STRINGS.OCEAN,
            },
            spawnLocation = Mob.Location.LiquidFloor,
        };

        public static SeedTuning ShlurpCoralSeedTuning = new SeedTuning
        {
            density = seedDensity,
            biomes = ShlurpCoralTuning.biomes,
            biomesExcluded = new HashSet<string>() {
                BAATOR_BIOME_STRINGS.MINAUROS,
                BAATOR_BIOME_STRINGS.AVERNUS,
            },
        };

        public struct PlantTuning
        {
            public MinMax density;
            public float lethalLow;
            public float warningLow;
            public float transitionLow;
            public float transitionTemp;
            public float transitionHigh;
            public float warningHigh;
            public float lethalhigh;
            public float defaultTemperature;
            public EffectorValues juvenileDecor;
            public EffectorValues matureDecor;
            public EffectorValues flourishingDecor;
            public SimHashes[] safeElements;
            public ISet<Temperatures> biomeTemperatures;
            public ISet<string> biomes;
            public ISet<string> biomesExcluded;
            public Mob.Location spawnLocation;

            // Check that the subworld temperature and current biome are appropriate for the plant
            public bool ValidBiome(SubWorld subworld, string biome)
            {
                return biomeTemperatures.Contains(subworld.temperatureRange) && (biomesExcluded == null || !biomesExcluded.Any(b => biome.Contains(b))) && biomes.Any(b => biome.Contains(b));
            }
        }

        public struct SeedTuning
        {
            public MinMax density;
            public ISet<string> biomes;
            public ISet<string> biomesExcluded;

            // Check that current biome are appropriate for the plant seed
            public bool ValidBiome(string biome)
            {
                return (biomesExcluded == null || !biomesExcluded.Any(b => biome.Contains(b))) && biomes.Any(b => biome.Contains(b));
            }
        }
    }
}