using Microsoft.AspNetCore.Mvc;
using Pokedex.Cache;
using Pokedex.Filters;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{

    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ServiceFilter(typeof(ValidationFilter))]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    [Route("Pokemon/v1/Standard/")]
    public class StandardPokemonController : ControllerBase
    {

        private readonly ILogger<StandardPokemonController> _logger;
        private readonly IConfiguration _configuration;
        private readonly StandardCacheManager _cacheManager;

        public StandardPokemonController(ILogger<StandardPokemonController> logger, IConfiguration configuration, StandardCacheManager cacheManager)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Gets Pokemon details with Standard Description.
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns><see cref="Pokemon"/> type object/json.</returns>
        [HttpGet]
        [Route("{name?}")]
        public IActionResult Get(string? name)
        {
            StandardPokemonService svc = new(_configuration, _cacheManager);
            Task<Pokemon> pokemon = svc.GetAsync(name);
            return Ok(pokemon.Result);
        }
    }
}
