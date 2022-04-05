using Newtonsoft.Json;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class CommonService
    {
        /// <summary>
        /// Maps the .
        /// A generic object is returned of type mentioned in param. usage requires explicitly typecasted.
        /// </summary>
        /// <param name="response">json string.</param>
        /// /// <param name="type">class type.</param>
        /// <returns><see cref="object"/> Generic object.</returns>
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
