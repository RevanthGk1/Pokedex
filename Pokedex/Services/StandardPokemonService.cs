using Newtonsoft.Json;
using Pokedex.ExtServices;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class StandardPokemonService
    {
        private readonly IConfiguration _configuration;

        public StandardPokemonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the response and processes the raw response accordingly.
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>A <see cref="Task{Pokemon}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Pokemon> GetAsync(string name)
        {
            string response = string.Empty;
            PokeApiClient client = new(_configuration);
            response = await client.GetAsync(name);
            PokemonSpecies pokemonSpecies = ProcessResponse(response);
            Pokemon pokemon = Map(pokemonSpecies);
            return pokemon;
        }

        private static PokemonSpecies ProcessResponse(string response)
        {
            PokemonSpecies pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response);
            return pokemonSpecies;
        }

        private static Pokemon Map(PokemonSpecies pokemonSpecies)
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
