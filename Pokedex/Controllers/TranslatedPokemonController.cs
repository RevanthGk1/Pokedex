using Microsoft.AspNetCore.Mvc;
using Pokedex.Filters;

namespace Pokedex.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ServiceFilter(typeof(ValidationFilter))]
    [Route("Pokemon/v1/Translated/")]
    public class TranslatedPokemonController : ControllerBase
    {
        private readonly ILogger<TranslatedPokemonController> _logger;

        public TranslatedPokemonController(ILogger<TranslatedPokemonController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Gets Pokemon details like Name, Modified-Description, Habitat, Is_Legendary etc.
        /// Api:Pokemon/v1/Translated/<paramref name="name"/>.
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns><see cref="Pokemon"/> type object/json.</returns>
        [HttpGet]
        [Route("{name?}")]
        public IActionResult Get(string? name)
        {

            return Ok("Pokemon Found " + name);
        }

    }
}
