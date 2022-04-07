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
            PokemonSpeciesFlavorTexts flvTxts = null;

            if (pokemonSpecies != null && pokemonSpecies.FlavorTextEntries != null && pokemonSpecies.FlavorTextEntries.Count > 0)
            {
                flvTxts = pokemonSpecies.FlavorTextEntries.FirstOrDefault(x => x.Language.Name == "en");

                if (flvTxts == null)
                    flvTxts = pokemonSpecies.FlavorTextEntries.FirstOrDefault();
            }

            Pokemon pokemon = new()
            {
                Name = pokemonSpecies.Name,
                Id = pokemonSpecies.Id,
                Description = flvTxts.FlavorText,
                Habitat = pokemonSpecies.Habitat.Name,
                IsLegendary = pokemonSpecies.IsLegendary,
            };

            return pokemon;
        }
    }
}
