using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class IcyShroomConfig : IEntityConfig
    {
        public const string Id = "IcyShroom";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = IcyShroomTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            string desc = STRINGS.PLANTS.ICYSHROOM.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ColdLovingPlant>(Id,
                STRINGS.PLANTS.ICYSHROOM.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.ICYSHROOM.SEED_NAME,
                STRINGS.SEEDS.ICYSHROOM.SEED_DESC,
                tuning);

            var coldPlant = plantEntityTemplate.AddOrGet<ColdLovingPlant>();
            coldPlant.lowTransition = tuning.transitionLow;
            coldPlant.highTransition = tuning.transitionHigh;

            return plantEntityTemplate;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}