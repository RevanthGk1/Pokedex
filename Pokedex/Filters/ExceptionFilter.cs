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
            if (context.HttpContext.Response.StatusCode == StatusCodes.Status200OK)
            {
                context.Result = new NotFoundObjectResult("Pokemon Not found");
            }

            _logger.LogError(context.Exception, context.HttpContext.Request.Body.ToString());
        }
    }
}
