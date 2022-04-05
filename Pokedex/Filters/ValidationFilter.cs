namespace Pokedex.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Security.Application;

    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param =  context.ActionArguments.SingleOrDefault(p => p.Key == "name");

            if (context.ActionArguments.Count < 1 || param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Pokemon name cannot be empty");
                return;
            }

            string sanitized = Sanitizer.GetSafeHtmlFragment(param.Value.ToString());

            if (string.IsNullOrEmpty(sanitized))
            {
                context.Result = new BadRequestObjectResult("Pokemon name is malformed");
                return;
            }

            context.ActionArguments["name"] = sanitized;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
