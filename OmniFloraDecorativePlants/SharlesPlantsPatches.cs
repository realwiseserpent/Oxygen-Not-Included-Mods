/*
	MIT License

	Copyright (c) 2020 Steven Brelsford (Versepelles)

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HarmonyLib;
using Klei;
using ProcGen;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;
using static STRINGS.CODEX;

namespace SharlesPlants
{
    class SharlesPlantsPatches
    {
        public static Dictionary<string, PlantTuning> PlantDictionary;
        public static Dictionary<string, SeedTuning> SeedDictionary;

        public static void InitCropDictionary()
        {
            Log("Loading plants", true);

            PlantDictionary = new Dictionary<string, PlantTuning>()
                {
                    { PricklyLotusConfig.Id, PricklyLotusTuning },
                    { FrostBlossomConfig.Id, FrostBlossomTuning },
                    { IcyShroomConfig.Id, IcyShroomTuning },
                    { MyrthRoseConfig.Id, MyrthRoseTuning },
                    { RustFernConfig.Id, RustFernTuning },
                    { SporeLampConfig.Id, SporeLampTuning },
                    { TropicalgaeConfig.Id, TropicalgaeTuning },
                    { ShlurpCoralConfig.Id, ShlurpCoralTuning },
                };
            SeedDictionary = new Dictionary<string, SeedTuning>()
                {
                    { PricklyLotusConfig.SeedId, PricklyLotusSeedTuning },
                    { FrostBlossomConfig.SeedId, FrostBlossomSeedTuning },
                    { IcyShroomConfig.SeedId, IcyShroomSeedTuning },
                    { MyrthRoseConfig.SeedId, MyrthRoseSeedTuning },
                    { RustFernConfig.SeedId, RustFernSeedTuning },
                    { SporeLampConfig.SeedId, SporeLampSeedTuning },
                    { TropicalgaeConfig.SeedId, TropicalgaeSeedTuning },
                    { ShlurpCoralConfig.SeedId, ShlurpCoralSeedTuning },
                };
        }

        // Reveal map on startup (Debug only)
        [HarmonyPatch(typeof(MinionSelectScreen), "OnProceed")]
        public static class MinionSelectScreen_OnProceed_Patch
        {
            private static void Postfix()
            {
                Log("MinionSelectScreen_OnProceed_Patch Postfix");
                if (DebugMode)
                {
                    int radius = (int)(Math.Max(Grid.WidthInCells, Grid.HeightInCells) * 1.5f);
                    GridVisibility.Reveal(0, 0, radius, radius - 1);
                }
            }
        }

        // Waterweed drowning fix
        [HarmonyPatch(typeof(SeaLettuceConfig), "CreatePrefab")]
        public static class SeaLettuceConfig_CreatePrefab_Patch
        {
            private static void Postfix(GameObject __result)
            {
                Log("EntityTemplates_ExtendEntityToBasicPlant_Patch Postfix");
                var drowningMonitor = __result.GetComponent<DrowningMonitor>();
                if (drowningMonitor != null)
                    drowningMonitor.enabled = false;
            }
        }

        // Register plants and seeds to the game
        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public static class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                Log("EntityConfigManager_LoadGeneratedEntities_Patch Prefix");

                //RegisterPlantCodex(PricklyLotusConfig.Id, STRINGS.PLANTS.PRICKLYLOTUS.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(FrostBlossomConfig.Id, STRINGS.PLANTS.FROSTBLOSSOM.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(IcyShroomConfig.Id, STRINGS.PLANTS.ICYSHROOM.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(MyrthRoseConfig.Id, STRINGS.PLANTS.MYRTHROSE.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(RustFernConfig.Id, STRINGS.PLANTS.RUSTFERN.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(SporeLampConfig.Id, STRINGS.PLANTS.SPORELAMP.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(TropicalgaeConfig.Id, STRINGS.PLANTS.TROPICALGAE.NAME, STRINGS.CODEX.SUBTITLE);
                //RegisterPlantCodex(ShlurpCoralConfig.Id, STRINGS.PLANTS.SHLURPCORAL.NAME, STRINGS.CODEX.SUBTITLE);

                RegisterPlant(PricklyLotusConfig.Id, STRINGS.PLANTS.PRICKLYLOTUS.NAME, STRINGS.PLANTS.PRICKLYLOTUS.DESC, STRINGS.PLANTS.PRICKLYLOTUS.DOMESTICATED_DESC);
                RegisterSeed(PricklyLotusConfig.SeedId, STRINGS.SEEDS.PRICKLYLOTUS.SEED_NAME, STRINGS.SEEDS.PRICKLYLOTUS.SEED_DESC);
                RegisterPlant(FrostBlossomConfig.Id, STRINGS.PLANTS.FROSTBLOSSOM.NAME, STRINGS.PLANTS.FROSTBLOSSOM.DESC, STRINGS.PLANTS.FROSTBLOSSOM.DOMESTICATED_DESC);
                RegisterSeed(FrostBlossomConfig.SeedId, STRINGS.SEEDS.FROSTBLOSSOM.SEED_NAME, STRINGS.SEEDS.FROSTBLOSSOM.SEED_DESC);
                RegisterPlant(IcyShroomConfig.Id, STRINGS.PLANTS.ICYSHROOM.NAME, STRINGS.PLANTS.ICYSHROOM.DESC, STRINGS.PLANTS.ICYSHROOM.DOMESTICATED_DESC);
                RegisterSeed(IcyShroomConfig.SeedId, STRINGS.SEEDS.ICYSHROOM.SEED_NAME, STRINGS.SEEDS.ICYSHROOM.SEED_DESC);
                RegisterPlant(MyrthRoseConfig.Id, STRINGS.PLANTS.MYRTHROSE.NAME, STRINGS.PLANTS.MYRTHROSE.DESC, STRINGS.PLANTS.MYRTHROSE.DOMESTICATED_DESC);
                RegisterSeed(MyrthRoseConfig.SeedId, STRINGS.SEEDS.MYRTHROSE.SEED_NAME, STRINGS.SEEDS.MYRTHROSE.SEED_DESC);
                RegisterPlant(RustFernConfig.Id, STRINGS.PLANTS.RUSTFERN.NAME, STRINGS.PLANTS.RUSTFERN.DESC, STRINGS.PLANTS.RUSTFERN.DOMESTICATED_DESC);
                RegisterSeed(RustFernConfig.SeedId, STRINGS.SEEDS.RUSTFERN.SEED_NAME, STRINGS.SEEDS.RUSTFERN.SEED_DESC);
                RegisterPlant(SporeLampConfig.Id, STRINGS.PLANTS.SPORELAMP.NAME, STRINGS.PLANTS.SPORELAMP.DESC, STRINGS.PLANTS.SPORELAMP.DOMESTICATED_DESC);
                RegisterSeed(SporeLampConfig.SeedId, STRINGS.SEEDS.SPORELAMP.SEED_NAME, STRINGS.SEEDS.SPORELAMP.SEED_DESC);
                RegisterPlant(TropicalgaeConfig.Id, STRINGS.PLANTS.TROPICALGAE.NAME, STRINGS.PLANTS.TROPICALGAE.DESC, STRINGS.PLANTS.TROPICALGAE.DOMESTICATED_DESC);
                RegisterSeed(TropicalgaeConfig.SeedId, STRINGS.SEEDS.TROPICALGAE.SEED_NAME, STRINGS.SEEDS.TROPICALGAE.SEED_DESC);
                RegisterPlant(ShlurpCoralConfig.Id, STRINGS.PLANTS.SHLURPCORAL.NAME, STRINGS.PLANTS.SHLURPCORAL.DESC, STRINGS.PLANTS.SHLURPCORAL.DOMESTICATED_DESC);
                RegisterSeed(ShlurpCoralConfig.SeedId, STRINGS.SEEDS.SHLURPCORAL.SEED_NAME, STRINGS.SEEDS.SHLURPCORAL.SEED_DESC);
            }
        }

        // Add plants to Mob Dictionary
        [HarmonyPatch(typeof(SettingsCache), "LoadFiles", new Type[] { typeof(string), typeof(string), typeof(List<YamlIO.Error>) })]
        public static class SettingsCache_LoadFiles_Patch
        {
            public static void Postfix()
            {
                Log("SettingsCache_LoadFiles_Patch Postfix");

                var mobs = SettingsCache.mobs.MobLookupTable;

                foreach (string plantName in PlantDictionary.Keys)
                {
                    if (mobs.ContainsKey(plantName))
                        continue;
                    var tuning = PlantDictionary[plantName];
                    Mob plant = new Mob(tuning.spawnLocation) { name = plantName };
                    var p = Traverse.Create(plant);
                    p.Property("width").SetValue(1);
                    p.Property("height").SetValue(1);
                    p.Property("density").SetValue(tuning.density);
                    p.Property("selectMethod", null).SetValue(1);
                    mobs.Add(plantName, plant);
                }
                if (Settings.Instance.BaseSettings.SeedsSpawn)
                    foreach (string seedName in SeedDictionary.Keys)
                    {
                        if (mobs.ContainsKey(seedName))
                            continue;
                        var tuning = SeedDictionary[seedName];
                        Mob plant = new Mob(Mob.Location.Solid) { name = seedName };

                        var p = Traverse.Create(plant);
                        p.Property("width").SetValue(1);
                        p.Property("height").SetValue(1);
                        p.Property("density").SetValue(tuning.density);
                        p.Property("selectMethod", null).SetValue(1);
                        mobs.Add(seedName, plant);
                    }
            }
        }

        // Add plants to Biome presets
        [HarmonyPatch(typeof(SettingsCache), "LoadSubworlds")]
        public static class SettingsCache_LoadSubworlds_Patch
        {
            public static void Postfix()
            {
                Log("SettingsCache_LoadSubworlds_Patch Postfix");

                foreach (var subworld in SettingsCache.subworlds.Values)
                    foreach (var biome in subworld.biomes)
                    {
                        if (biome.tags == null)
                            Traverse.Create(biome).Property("tags").SetValue(new List<string>());

                        foreach (string plantName in PlantDictionary.Keys)
                            if (PlantDictionary[plantName].ValidBiome(subworld, biome.name))
                                if (!biome.tags.Contains(plantName))
                                    biome.tags.Add(plantName);

                        if (Settings.Instance.BaseSettings.SeedsSpawn)
                            foreach (string seedName in SeedDictionary.Keys)
                                if (SeedDictionary[seedName].ValidBiome(biome.name))
                                    if (!biome.tags.Contains(seedName))
                                        biome.tags.Add(seedName);
                    }
            }
        }

        // Add care package drops
        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref Immigration __instance)
            {
                Log("Immigration_ConfigureCarePackages_Patch Postfix");

                var field = Traverse.Create(__instance).Field("carePackages");
                List<CarePackageInfo> list = field.GetValue() as List<CarePackageInfo>;

                if (list.FindIndex(x => x.id.ToUpper() == "BulbPlantSeed".ToUpper()) == -1)
                    list.Add(new CarePackageInfo("BulbPlantSeed", 3f, null)); // add Buddy Bud seeds
                if (list.FindIndex(x => x.id.ToUpper() == "EvilFlowerSeed".ToUpper()) == -1)
                    list.Add(new CarePackageInfo("EvilFlowerSeed", 1f, () => GameClock.Instance.GetCycle() >= 24)); // add Sporechid seeds
                list.Add(new CarePackageInfo(PricklyLotusConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(FrostBlossomConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(IcyShroomConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(MyrthRoseConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(RustFernConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(SporeLampConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(TropicalgaeConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(ShlurpCoralConfig.SeedId, 3f, null));
                field.SetValue(list);
            }
        }

        // Add Molecular Forge recipes
        [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
        public class SupermaterialRefineryConfig_ConfigureBuildingTemplate_Patch
        {
            public static void Postfix()
            {
                Log("SupermaterialRefineryConfig_ConfigureBuildingTemplate_Patch Postfix");

                RegisterSeedRecipe(PricklyLotusConfig.SeedId, "CactusPlantSeed", SimHashes.Sand, 470);
                RegisterSeedRecipe(FrostBlossomConfig.SeedId, "ColdWheatSeed", SimHashes.Tungsten, 471);
                RegisterSeedRecipe(IcyShroomConfig.SeedId, "MushroomSeed", SimHashes.Wolframite, 472);
                RegisterSeedRecipe(MyrthRoseConfig.SeedId, "LeafyPlantSeed", SimHashes.Fertilizer, 473);
                RegisterSeedRecipe(RustFernConfig.SeedId, "OxyfernSeed", SimHashes.Rust, 474);
                RegisterSeedRecipe(SporeLampConfig.SeedId, "MushroomSeed", SimHashes.Carbon, 475);
                RegisterSeedRecipe(TropicalgaeConfig.SeedId, "BulbPlantSeed", SimHashes.Algae, 476);
                RegisterSeedRecipe(ShlurpCoralConfig.SeedId, "ColdBreatherSeed", SimHashes.Salt, 477);
            }
        }

        public static void RegisterPlant(string plantId, string name, string description, string domesticatedDescription)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, plantId));
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DESC", description);
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DOMESTICATEDDESC", domesticatedDescription);
        }

        public static void RegisterSeed(string seedId, string seedName, string seedDescription)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{seedId.ToUpperInvariant()}.NAME", UI.FormatAsLink(seedName, seedId));
            Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{seedId.ToUpperInvariant()}.DESC", seedDescription);
        }

        public static void RegisterPlantCodex(string plantId, string name, string subtitle, string body = "")
        {
            Strings.Add($"STRINGS.CODEX.{plantId.ToUpperInvariant()}.TITLE", name);
            Strings.Add($"STRINGS.CODEX.{plantId.ToUpperInvariant()}.SUBTITLE", subtitle);
            if (body != "")
                Strings.Add($"STRINGS.CODEX.{plantId.ToUpperInvariant()}.BODY.CONTAINER1", body);
        }

        public static void RegisterSeedRecipe(string seedName, Tag seedIngredient, SimHashes materialIngredient, int sortOrder)
        {
            var ingredients = new ComplexRecipe.RecipeElement[]
            {
              new ComplexRecipe.RecipeElement(seedIngredient, 1f),
              new ComplexRecipe.RecipeElement(materialIngredient.CreateTag(), 1f),
            };
            var results = new ComplexRecipe.RecipeElement[]
            {
              new ComplexRecipe.RecipeElement(seedName, 1f)
            };
            var recipeId = ComplexRecipeManager.MakeRecipeID(SupermaterialRefineryConfig.ID, ingredients, results);
            new ComplexRecipe(recipeId, ingredients, results)
            {
                time = 100f,
                //description = null,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag> { SupermaterialRefineryConfig.ID },
                sortOrder = sortOrder,
            };
        }

        public static void Log(string msg, bool force = false)
        {
            if (DebugMode || force)
                Console.WriteLine($"<<Sharles Plants>> {msg}");
        }

        [HarmonyPatch(typeof(CodexEntry))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] {
            typeof(string),
            typeof(List<ContentContainer>),
            typeof(string)
        })]
        public static class CodexEntry_Constructor_Patch
        {
            private static void Postfix(CodexEntry __instance)
            {
                if (!Settings.Instance.BaseSettings.ExtendedDesc || __instance.category != "PLANTS")
                    return;

                GameObject frost = Assets.GetPrefab(FrostBlossomConfig.Id);
                GameObject mushroom = Assets.GetPrefab(IcyShroomConfig.Id);
                GameObject myrth = Assets.GetPrefab(MyrthRoseConfig.Id);
                GameObject pricky = Assets.GetPrefab(PricklyLotusConfig.Id);
                GameObject rust = Assets.GetPrefab(RustFernConfig.Id);
                GameObject shlurp = Assets.GetPrefab(ShlurpCoralConfig.Id);
                GameObject spore = Assets.GetPrefab(SporeLampConfig.Id);
                GameObject tropic = Assets.GetPrefab(TropicalgaeConfig.Id);


                if (frost.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(FrostBlossomConfig.Id));
                else if (mushroom.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(IcyShroomConfig.Id));
                else if (myrth.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(MyrthRoseConfig.Id));
                else if (pricky.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(PricklyLotusConfig.Id));
                else if (rust.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(RustFernConfig.Id));
                else if (shlurp.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(ShlurpCoralConfig.Id));
                else if (spore.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(SporeLampConfig.Id));
                else if (tropic.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(TropicalgaeConfig.Id));
            }
        }

        private static List<ContentContainer> GetCodexContainers(string id)
        {
            string desc = "";

            GameObject go = Assets.GetPrefab(id);

            WarmLovingPlant warm = go.GetComponent<WarmLovingPlant>();
            ColdLovingPlant cold = go.GetComponent<ColdLovingPlant>();
            ReactivePlant react = go.GetComponent<ReactivePlant>();
            WaterPlant water = go.GetComponent<WaterPlant>();

            if (warm != null)
                desc +=
                string.Format(STRINGS.MISC.MATURESABOVE, GameUtil.GetFormattedTemperature(warm.lowTransition)) +
                "\n" + string.Format(STRINGS.MISC.FLOURISHESABOVE, GameUtil.GetFormattedTemperature(warm.highTransition));

            if (cold != null)
                desc +=
                string.Format(STRINGS.MISC.MATURESBELOW, GameUtil.GetFormattedTemperature(cold.highTransition)) +
                "\n" + string.Format(STRINGS.MISC.FLOURISHESBELOW, GameUtil.GetFormattedTemperature(cold.lowTransition));

            if (react != null)
            {
                desc +=
                string.Format(STRINGS.MISC.REACTSABOVEWITH, GameUtil.GetFormattedTemperature(react.requiredTemperature));

                foreach (SimHashes hash in react.reactiveElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            }

            if (water != null)
            {
                desc +=
                string.Format(STRINGS.MISC.FLOURISHESABOVEIN, GameUtil.GetFormattedTemperature(water.preferredTemperature));
                foreach (SimHashes hash in water.preferredElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;

                desc += "\n" + STRINGS.MISC.TOLERATES;
                foreach (SimHashes hash in water.toleratedElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            }


            return new List<ContentContainer>()
                {
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                        new CodexText() { stringKey = $"STRINGS.CREATURES.SPECIES.{id.ToUpperInvariant()}.NAME",
                            style = CodexTextStyle.Title },
                        new CodexText() { stringKey = $"STRINGS.CODEX.MIRTHLEAF.SUBTITLE",
                            style = CodexTextStyle.Subtitle },
                        new CodexDividerLine() { preferredWidth = -1 }
                        }
                    },
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                            new CodexText(desc) { style = CodexTextStyle.Body }
                        }
                    }
                };
        }

        //[HarmonyPatch(typeof(CodexEntryGenerator), "GeneratePlantEntries")]
        public class SharlesPlants_CodexEntryGenerator_GeneratePlantEntries_Patch
        {
            public static void Postfix(Dictionary<string, CodexEntry> __result)
            {
                if (Settings.Instance.BaseSettings.ExtendedDesc)
                    foreach (var key in PlantDictionary.Keys)
                        UpdateCodex(key);
            }
        }

        private static void UpdateCodex(string id)
        {
            CodexEntry entry = CodexCache.FindEntry(id.ToUpperInvariant());
            GameObject go = Assets.GetPrefab(id);

            if (entry == null || go == null)
                return;

            string desc = "";

            WarmLovingPlant warm = go.GetComponent<WarmLovingPlant>();
            ColdLovingPlant cold = go.GetComponent<ColdLovingPlant>();
            ReactivePlant react = go.GetComponent<ReactivePlant>();
            WaterPlant water = go.GetComponent<WaterPlant>();

            if (warm != null)
                desc +=
                string.Format(STRINGS.MISC.MATURESABOVE, GameUtil.GetFormattedTemperature(warm.lowTransition)) +
                "\n" + string.Format(STRINGS.MISC.FLOURISHESABOVE, GameUtil.GetFormattedTemperature(warm.highTransition));

            if (cold != null)
                desc +=
                string.Format(STRINGS.MISC.MATURESBELOW, GameUtil.GetFormattedTemperature(cold.highTransition)) +
                "\n" + string.Format(STRINGS.MISC.FLOURISHESBELOW, GameUtil.GetFormattedTemperature(cold.lowTransition));

            if (react != null)
            {
                desc +=
                string.Format(STRINGS.MISC.REACTSABOVEWITH, GameUtil.GetFormattedTemperature(react.requiredTemperature));

                foreach (SimHashes hash in react.reactiveElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            }

            if (water != null)
            {
                desc +=
                string.Format(STRINGS.MISC.FLOURISHESABOVEIN, GameUtil.GetFormattedTemperature(water.preferredTemperature));
                foreach (SimHashes hash in water.preferredElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;

                desc += "\n" + STRINGS.MISC.TOLERATES;
                foreach (SimHashes hash in water.toleratedElements)
                    desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            }

            entry.contentContainers.InsertRange(0, new List<ContentContainer>()
                {
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                        new CodexText(go.GetProperName()) {
                            style = CodexTextStyle.Title },
                        new CodexText() {
                            stringKey = $"STRINGS.CODEX.MIRTHLEAF.SUBTITLE",
                            style = CodexTextStyle.Subtitle },
                        new CodexDividerLine() {
                            preferredWidth = -1 }
                        }
                    },
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                        new CodexText(desc) {
                            style = CodexTextStyle.Body }
                        }
                    }
                });
        }
    }
}