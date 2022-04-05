using Newtonsoft.Json;
using Pokedex.ExtServices;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class TranslatedPokemonService
    {
        private readonly IConfiguration _configuration;

        public TranslatedPokemonService(IConfiguration configuration)
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
            PokemonSpecies pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response);
            Pokemon pokemon = CommonService.MapToPokemon(pokemonSpecies);
            this.TranslateDescription(pokemon);
            return pokemon;
        }

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
