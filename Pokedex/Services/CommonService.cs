using Newtonsoft.Json;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class CommonService
    {
        /// <summary>
        /// Deserializes the json string response based on the class type.
        /// A generic object is returned of type mentioned in param. usage requires explicitly typecasted.
        /// </summary>
        /// <param name="response">json string.</param>
        /// /// <param name="type">class type.</param>
        /// <returns><see cref="object"/> Generic object.</returns>
        //public static object DeserializeResponse(string response, Type type)
        //{
        //    //var dsrObj = Activator.CreateInstance(type);
        //    var dsrObj = JsonConvert.DeserializeObject(response, type);
        //    return dsrObj;
        //}

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
