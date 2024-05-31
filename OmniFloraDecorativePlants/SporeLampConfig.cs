using System.Collections.Generic;
using UnityEngine;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    public class SporeLampConfig : IEntityConfig
    {
        public const string Id = "SporeLamp";
        public const string SeedId = Id + "Seed";

        public static PlantTuning tuning = SporeLampTuning;

        public string[] GetDlcIds()
        {
            return SupportedVersions;
        }

        public GameObject CreatePrefab()
        {
            List<SimHashes> reactiveElements = new List<SimHashes>()
                {
                    SimHashes.Methane,
                    SimHashes.SourGas,
                    SimHashes.Hydrogen,
                    SimHashes.EthanolGas,
                };

            string desc = STRINGS.PLANTS.SPORELAMP.DESC;

            var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ReactivePlant>(Id,
                STRINGS.PLANTS.SPORELAMP.NAME,
                desc,
                SeedId,
                STRINGS.SEEDS.SPORELAMP.SEED_NAME,
                STRINGS.SEEDS.SPORELAMP.SEED_DESC,
                tuning);

            var reactivePlant = plantEntityTemplate.AddOrGet<ReactivePlant>();
            reactivePlant.requiredTemperature = tuning.transitionTemp;
            reactivePlant.reactiveElements = reactiveElements;

            var light2D = plantEntityTemplate.AddOrGet<Light2D>();
            light2D.Color = new Color(1.0f, 0.8f, 1.0f);
            light2D.Lux = 1800;
            light2D.Range = 5;
            light2D.overlayColour = new Color(0.5f, 0.4f, 0.5f, 0.25f);
            light2D.drawOverlay = true;
            light2D.Offset = new Vector2(-0.05f, 0.7f);

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