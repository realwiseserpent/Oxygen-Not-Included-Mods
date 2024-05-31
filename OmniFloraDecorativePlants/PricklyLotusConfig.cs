using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class PricklyLotusConfig : IEntityConfig
    {
        public const string Id = "PricklyLotus";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = PricklyLotusTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            string desc = STRINGS.PLANTS.PRICKLYLOTUS.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WarmLovingPlant>(Id,
                STRINGS.PLANTS.PRICKLYLOTUS.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.PRICKLYLOTUS.SEED_NAME,
                STRINGS.SEEDS.PRICKLYLOTUS.SEED_DESC,
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