namespace Pokedex.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The flavor text for a Pokémon species.
    /// </summary>
    public class PokemonSpeciesFlavorTexts
    {
        /// <summary>
        /// The localized flavor text for an api resource in a specific language
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The game version this flavor text is extracted from.
        /// </summary>
        //public NamedApiResource<Version> Version { get; set; }

        /// <summary>
        /// The language this flavor text is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }
}