using Newtonsoft.Json;

namespace Pokedex.Models
{
    /// <summary>
    /// A Pokémon Species forms the basis for at least one Pokémon. Attributes
    /// of a Pokémon species are shared across all varieties of Pokémon within
    /// the species. A good example is Wormadam; Wormadam is the species which
    /// can be found in three different varieties, Wormadam-Trash,
    /// Wormadam-Sandy and Wormadam-Plant.
    /// </summary>
    public class PokemonSpecies : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-species";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The order in which species should be sorted. Based on National Dex
        /// order, except families are grouped together and sorted by stage.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for
        /// genderless.
        /// </summary>
        [JsonProperty("gender_rate")]
        public int GenderRate { get; set; }

        /// <summary>
        /// The base capture rate; up to 255. The higher the number, the easier
        /// the catch.
        /// </summary>
        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }

        /// <summary>
        /// The happiness when caught by a normal Pokéball; up to 255. The higher
        /// the number, the happier the Pokémon.
        /// </summary>
        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }

        /// <summary>
        /// Whether or not this is a baby Pokémon.
        /// </summary>
        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        /// <summary>
        /// Whether or not this is a legendary Pokémon.
        /// </summary>
        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

        /// <summary>
        /// Whether or not this is a mythical Pokémon.
        /// </summary>
        [JsonProperty("is_mythical")]
        public bool IsMythical { get; set; }

        /// <summary>
        /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps
        /// before this Pokémon's egg hatches, unless utilizing bonuses like
        /// Flame Body's.
        /// </summary>
        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has visual gender differences.
        /// </summary>
        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has multiple forms and can switch between
        /// them.
        /// </summary>
        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }


        /// <summary>
        /// The habitat this Pokémon species can be encountered in.
        /// </summary>
        public NamedApiResource<PokemonHabitat> Habitat { get; set; }


        /// <summary>
        /// A list of flavor text entries for this Pokémon species.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<PokemonSpeciesFlavorTexts> FlavorTextEntries { get; set; }

    }

}

