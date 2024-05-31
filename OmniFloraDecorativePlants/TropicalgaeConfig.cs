using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;
using System.Collections.Generic;

namespace SharlesPlants
{
    public class TropicalgaeConfig : IEntityConfig
    {
        public const string Id = "Tropicalgae";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = TropicalgaeTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            SimHashes[] preferredElements =
                {
                    SimHashes.DirtyWater,
                };
            SimHashes[] toleratedElements =
                {
                    SimHashes.Water,
                    SimHashes.SaltWater,
                    SimHashes.Brine,
                };
            string desc = STRINGS.PLANTS.TROPICALGAE.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WaterPlant>(Id,
                STRINGS.PLANTS.TROPICALGAE.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.TROPICALGAE.SEED_NAME,
                STRINGS.SEEDS.TROPICALGAE.SEED_DESC,
                tuning, canDrown: false);

            var waterPlant = plantEntityTemplate.AddOrGet<WaterPlant>();
            waterPlant.preferredTemperature = tuning.transitionTemp;

            waterPlant.preferredElements = new List<SimHashes>(preferredElements);
            waterPlant.toleratedElements = new List<SimHashes>(toleratedElements);

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