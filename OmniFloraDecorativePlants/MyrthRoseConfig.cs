using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class MyrthRoseConfig : IEntityConfig
    {
        public const string Id = "MyrthRose";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = MyrthRoseTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            string desc = STRINGS.PLANTS.MYRTHROSE.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WarmLovingPlant>(Id,
                STRINGS.PLANTS.MYRTHROSE.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.MYRTHROSE.SEED_NAME,
                STRINGS.SEEDS.MYRTHROSE.SEED_DESC,
                tuning);

            var warmPlant = plantEntityTemplate.AddOrGet<WarmLovingPlant>();
            warmPlant.lowTransition = tuning.transitionLow;
            warmPlant.highTransition = tuning.transitionHigh;

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