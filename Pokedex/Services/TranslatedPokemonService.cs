using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pokedex.Cache;
using Pokedex.ExtServices;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class TranslatedPokemonService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheManager _cache;

        public TranslatedPokemonService(IConfiguration configuration, IMemoryCache memoryCache)
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
                this.TranslateDescription(pokemon);
                _cache.Set(name, pokemon);
            }

            
            return pokemon;
        }

        /// <summary>
        /// Calls the client to get the translation based on legendary status & habitat.
        /// </summary>
        /// <param name="pokemon">pokemon</param>
        /// <returns>A <see cref="Task{Pokemon}"/> representing the result of the asynchronous operation.</returns>
        public async void TranslateDescription(Pokemon pokemon)
        {
            string habitat = _configuration["spclHabitat"];
            string trnDesc = string.Empty;
            TranslationApiClient trnClient = new(_configuration);
            if (pokemon.IsLegendary || pokemon.Habitat.Equals(habitat))
            {
                trnDesc = await trnClient.GetAsyncYoda(pokemon.Description);
            }
            else
            {
                trnDesc = await trnClient.GetAsyncShakespeare(pokemon.Description);
            }

            pokemon.Description = trnDesc;
        }

    }
}
