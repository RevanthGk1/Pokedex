using Microsoft.Extensions.Caching.Memory;
using Microsoft.Security.Application;
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
        private readonly TranslatedCacheManager _cacheManager;

        public TranslatedPokemonService(IConfiguration configuration, TranslatedCacheManager cacheManager)
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
                this.TranslateDescription(pokemon);
                _cacheManager.Set(name, pokemon);
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
            string uri = _configuration["Urls:shakespeareApi"];
            TranslationApiClient trnClient = new();
            if (pokemon.IsLegendary || pokemon.Habitat.Equals(habitat))
            {
                uri = _configuration["Urls:yodaApi"];
            }

            string sanitizedDesc = Sanitizer.GetSafeHtmlFragment(pokemon.Description);

            string contentstr = await trnClient.GetResponseAsync(sanitizedDesc, uri);

            TranslationContent trnContent = JsonConvert.DeserializeObject<TranslationContent>(contentstr);

            if (trnContent != null && trnContent.contents != null && !string.IsNullOrEmpty(trnContent.contents.translated))
            {
                pokemon.Description = trnContent.contents.translated;
            }
        }
    }
}
