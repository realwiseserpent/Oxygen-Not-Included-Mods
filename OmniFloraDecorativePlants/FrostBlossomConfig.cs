using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class FrostBlossomConfig : IEntityConfig
    {
        public const string Id = "FrostBlossom";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = FrostBlossomTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            string desc = STRINGS.PLANTS.FROSTBLOSSOM.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ColdLovingPlant>(Id,
                STRINGS.PLANTS.FROSTBLOSSOM.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.FROSTBLOSSOM.SEED_NAME,
                STRINGS.SEEDS.FROSTBLOSSOM.SEED_DESC,
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