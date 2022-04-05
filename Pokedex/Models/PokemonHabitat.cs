using Newtonsoft.Json;

namespace Pokedex.Models
{
    /// <summary>
    /// Habitats are generally different terrain Pokémon can be found in but
    /// can also be areas designated for rare or legendary Pokémon.
    /// </summary>
    public class PokemonHabitat : NamedApiResource
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
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// Gets or sets a list of the Pokémon species that can be found in this habitat.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }
}