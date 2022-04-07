using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pokedex.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Response.StatusCode == StatusCodes.Status200OK && context.Exception.Message.Contains(StatusCodes.Status404NotFound.ToString()))
            {
                context.Result = new NotFoundObjectResult("Pokemon Not found");
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound; // If the PokiAPi Server could send proper Status code that could have avoided above hardcoded condition & this hardcoding of statuscode.
            }
            else
            {
                _logger.LogError(context.Exception, context.Exception.StackTrace);
                context.Result = new  StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
