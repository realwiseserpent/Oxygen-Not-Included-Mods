using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;
using System.Collections.Generic;

namespace SharlesPlants
{
    public class ShlurpCoralConfig : IEntityConfig
    {
        public const string Id = "ShlurpCoral";
        public const string SeedId = Id + "Polyp";

        public static PlantTuning tuning = ShlurpCoralTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            SimHashes[] preferredElements =
                {
                    SimHashes.SaltWater,
                    SimHashes.Brine,
               };
            SimHashes[] toleratedElements =
                {
                    SimHashes.Water,
                    SimHashes.DirtyWater,
               };

            string desc = STRINGS.PLANTS.SHLURPCORAL.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WaterPlant>(Id,
                STRINGS.PLANTS.SHLURPCORAL.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.SHLURPCORAL.SEED_NAME,
                STRINGS.SEEDS.SHLURPCORAL.SEED_DESC,
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