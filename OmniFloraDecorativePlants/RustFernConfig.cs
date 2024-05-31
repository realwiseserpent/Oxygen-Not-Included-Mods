using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class RustFernConfig : IEntityConfig
    {
        public const string Id = "RustFern";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = RustFernTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            string desc = STRINGS.PLANTS.RUSTFERN.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ColdLovingPlant>(Id,
                STRINGS.PLANTS.RUSTFERN.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.RUSTFERN.SEED_NAME,
                STRINGS.SEEDS.RUSTFERN.SEED_DESC,
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