using STRINGS;

namespace SharlesPlants
{
    class STRINGS
    {
        public class PLANTS
        {
            public class FROSTBLOSSOM
            {
                public static LocString NAME = UI.FormatAsLink("Frost Blossom", nameof(FROSTBLOSSOM));
                public static LocString DESC = "A plant with exquisite petals that thrives in the chilliest of environments.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class ICYSHROOM
            {
                public static LocString NAME = UI.FormatAsLink("Icy Shroom", nameof(ICYSHROOM));
                public static LocString DESC = "An adorable little toadstool with a great affection for frigid conditions.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class MYRTHROSE
            {
                public static LocString NAME = UI.FormatAsLink("Myrth Rose", nameof(MYRTHROSE));
                public static LocString DESC = "A royalty among plants, prized for its alluring colors that fully emerge in warm climates.";
                public static LocString DOMESTICATED_DESC = DESC;
            }

            public class PRICKLYLOTUS
            {
                public static LocString NAME = UI.FormatAsLink("Prickly Lotus", nameof(PRICKLYLOTUS));
                public static LocString DESC = "This bulbous succulent is oddly reminiscent of a young duplicant but much easier to take care of.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class RUSTFERN
            {
                public static LocString NAME = UI.FormatAsLink("Rust Fern", nameof(RUSTFERN));
                public static LocString DESC = "The fronds of this fern are hardened by minerals absorbed from the soil. Cooler environments promote mineral formation.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class SHLURPCORAL
            {
                public static LocString NAME = UI.FormatAsLink("Shlurp Coral", nameof(SHLURPCORAL));
                public static LocString DESC = $"The result of genetic experimentation on {UI.FormatAsLink("Wheezeworts", "ColdBreather")}, this plant is actually a colony of symbiotic creatures.";
                public static LocString DOMESTICATED_DESC = DESC;

            }
            public class SPORELAMP
            {
                public static LocString NAME = UI.FormatAsLink("Spore Lamp", nameof(SPORELAMP));
                public static LocString DESC = "When immersed in a reactive element, this mycelial organism emits a mesmerizing glow that lures its prey into inhospitable environments. Their remains provide fertilizer for its spread.";
                public static LocString DOMESTICATED_DESC = DESC;

            }
            public class TROPICALGAE
            {
                public static LocString NAME = UI.FormatAsLink("Tropicalgae", nameof(TROPICALGAE));
                public static LocString DESC = "Many consider this plant to be an unsightly nuisance, but it provides shelter and food for aquatic life.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
        }
        public class SEEDS
        {
            public class FROSTBLOSSOM
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.FROSTBLOSSOM.NAME + " Seed", nameof(FROSTBLOSSOM));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("seed", "PLANTS")} of a {UI.FormatAsLink(PLANTS.FROSTBLOSSOM.NAME, FrostBlossomConfig.Id)}.";
            }
            public class ICYSHROOM
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.ICYSHROOM.NAME + " Spore", nameof(ICYSHROOM));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("spore", "PLANTS")} of a {UI.FormatAsLink(PLANTS.ICYSHROOM.NAME, IcyShroomConfig.Id)}.";
            }
            public class MYRTHROSE
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.MYRTHROSE.NAME + " Seed", nameof(MYRTHROSE));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("seed", "PLANTS")} of a {UI.FormatAsLink(PLANTS.MYRTHROSE.NAME, MyrthRoseConfig.Id)}.";
            }
            public class PRICKLYLOTUS
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.PRICKLYLOTUS.NAME + " Seed", nameof(PRICKLYLOTUS));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("seed bulb", "PLANTS")} of a {UI.FormatAsLink(PLANTS.PRICKLYLOTUS.NAME, PricklyLotusConfig.Id)}.";
            }
            public class RUSTFERN
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.RUSTFERN.NAME + " Seed", nameof(RUSTFERN));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("seed", "PLANTS")} of a {UI.FormatAsLink(PLANTS.RUSTFERN.NAME, RustFernConfig.Id)}.";
            }
            public class SHLURPCORAL
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.SHLURPCORAL.NAME + " Polyp", nameof(SHLURPCORAL));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("polyp", "PLANTS")} of a {UI.FormatAsLink(PLANTS.SHLURPCORAL.NAME, ShlurpCoralConfig.Id)}.";
            }
            public class SPORELAMP
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.SPORELAMP.NAME + " Spore", nameof(SPORELAMP));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("spore", "PLANTS")} of a {UI.FormatAsLink(PLANTS.SPORELAMP.NAME, SporeLampConfig.Id)}.";
            }
            public class TROPICALGAE
            {
                public static LocString SEED_NAME = UI.FormatAsLink(PLANTS.TROPICALGAE.NAME + " Seed", nameof(TROPICALGAE));
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("seed bulb", "PLANTS")} of a {UI.FormatAsLink(PLANTS.TROPICALGAE.NAME, TropicalgaeConfig.Id)}.";
            }
        }
        public class MISC
        {
            public static LocString FLOURISHESABOVEIN = "Flourishes above {0} in:";
            public static LocString TOLERATES = "Tolerates: ";
            public static LocString MATURESABOVE = "Matures above {0}";
            public static LocString FLOURISHESABOVE = "Flourishes above {0}";
            public static LocString REACTSABOVEWITH = "Reacts above {0} with:";
            public static LocString MATURESBELOW = "Matures below {0}";
            public static LocString FLOURISHESBELOW = "Flourishes below {0}";
        }
        public class TRANSLATION
        {
            public class AUTHOR
            {
                public static LocString NAME = "Versepelles";
            }
        }
    }
}
