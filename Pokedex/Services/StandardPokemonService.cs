using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pokedex.Cache;
using Pokedex.ExtServices;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class StandardPokemonService 
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly StandardCacheManager _cacheManager;

        public StandardPokemonService(IConfiguration configuration, StandardCacheManager cacheManager)
        {
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Gets the response and processes the raw response accordingly.
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>A <see cref="Task{Pokemon}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Pokemon> GetAsync(string name)
        {
            Pokemon pokemon = (Pokemon)_cacheManager.Get(name);
            if (pokemon == null || string.IsNullOrEmpty(pokemon.Description))
            {
                PokeApiClient client = new();
                string uri = _configuration["Urls:pokiApi"];
                string response = await client.GetPokemonByNameAsync(name, uri);
                PokemonSpecies pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response);
                pokemon = MapperService.MapToPokemon(pokemonSpecies);
                _cacheManager.Set(name, pokemon);
            }

            return pokemon;
        }
    }
}
