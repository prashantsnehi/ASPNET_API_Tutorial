using System;
using Microsoft.AspNetCore.Mvc.Filters;
using API_Tutorial.Controllers;
namespace API_Tutorial.Filters;


public class ResponseHeaderAsyncFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly ILogger<ResponseHeaderAsyncFilter> _logger;
    private readonly string _key;
    private readonly string _value;

    public int Order { get; set; }
    public ResponseHeaderAsyncFilter(ILogger<ResponseHeaderAsyncFilter> logger, string key, string value, int order)
	{
        _logger = logger;
        _key = key;
        _value = value;
        Order = order;
	}

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Response.Headers["X-Completed-At"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        context.HttpContext.Response.Headers[_key] = _value;
        if (context.Controller is AuthController authController)
        {
            if(!authController.ModelState.IsValid)
            {
                string errorMessages = string.Join("\n", authController.ModelState.Values.SelectMany(errors => errors.Errors).Select(error => error.ErrorMessage));

                // short circuiting or skip the subsequent action filters or action methods when we assign anything to context.result. 
                context.Result = authController.BadRequest(errorMessages);
            }
            else
            {
                // if model state is valid then it will execute subsequent filters or action methods.
                await next();
            }
        }
        else
        {
            // if context.controller is other than auth controller then also it will execute subsequent filters or action methods.
            await next();
        }
    }
}

