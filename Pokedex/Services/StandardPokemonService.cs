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
        private readonly CacheManager _cache;

        public StandardPokemonService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
            _cache = new CacheManager(_memoryCache);
        }

        /// <summary>
        /// Gets the response and processes the raw response accordingly.
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>A <see cref="Task{Pokemon}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Pokemon> GetAsync(string name)
        {
            Pokemon pokemon = (Pokemon)_cache.Get(name);
            if (pokemon == null || string.IsNullOrEmpty(pokemon.Description))
            {
                PokeApiClient client = new(_configuration);
                string response = await client.GetPokemonByNameAsync(name, CancellationToken.None);
                PokemonSpecies pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response);
                pokemon = MapperService.MapToPokemon(pokemonSpecies);
                _cache.Set(name, pokemon);
            }

            return pokemon;
        }
    }
}
