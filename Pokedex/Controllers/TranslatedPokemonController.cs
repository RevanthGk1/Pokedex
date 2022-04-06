using Microsoft.AspNetCore.Mvc;
using Pokedex.Filters;
using Pokedex.Services;
using Pokedex.Models;
using Microsoft.Extensions.Caching.Memory;
using Pokedex.Cache;

namespace Pokedex.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ServiceFilter(typeof(ValidationFilter))]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    [Route("Pokemon/v1/Translated/")]
    public class TranslatedPokemonController : ControllerBase
    {

        private readonly ILogger<TranslatedPokemonController> _logger;
        private readonly IConfiguration _configuration;
        private readonly TranslatedCacheManager _cacheManager;

        public TranslatedPokemonController(ILogger<TranslatedPokemonController> logger, IConfiguration configuration, TranslatedCacheManager cacheManager)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Gets Pokemon details with Translated Description
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns><see cref="Pokemon"/> type object/json.</returns>
        [HttpGet]
        [Route("{name?}")]
        public IActionResult Get(string? name)
        {
            TranslatedPokemonService svc = new(_configuration, _cacheManager);
            Task<Pokemon> pokemon = svc.GetAsync(name);
            return Ok(pokemon.Result);
        }

    }
}
