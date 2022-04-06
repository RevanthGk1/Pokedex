using Pokedex.Models;

namespace Pokedex.Services
{
    public class MapperService
    {
        /// <summary>
        /// Maps the from PokemonSpecies to Pokemon object.
        /// </summary>
        /// <param name="pokemonSpecies">pokemonSpecies.</param>
        /// <returns><see cref="Pokemon"/> Pokemon.</returns>
        public static Pokemon MapToPokemon(PokemonSpecies pokemonSpecies)
        {
            Pokemon pokemon = new()
            {
                Name = pokemonSpecies.Name,
                Id = pokemonSpecies.Id,
                Description = pokemonSpecies.FlavorTextEntries.FirstOrDefault(x => x.Language.Name == "en").FlavorText,
                Habitat = pokemonSpecies.Habitat.Name,
                IsLegendary = pokemonSpecies.IsLegendary
            };

            return pokemon;
        }
    }
}
