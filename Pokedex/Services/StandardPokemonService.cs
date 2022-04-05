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
            //PokemonSpecies pokemonSpecies = (PokemonSpecies)CommonService.DeserializeResponse(response, typeof(PokemonSpecies));
            PokemonSpecies pokemonSpecies = (PokemonSpecies)JsonConvert.DeserializeObject<PokemonSpecies>(response);
            Pokemon pokemon = CommonService.MapToPokemon(pokemonSpecies);
            return pokemon;
        }
    }
}
