using System;
using Microsoft.AspNetCore.Mvc.Filters;
namespace API_Tutorial.Filters;


public class ResponseHeaderFilter : IActionFilter
{
	private readonly ILogger<ResponseHeaderFilter> _logger;
    private readonly string _key;
    private readonly string _value;

    public ResponseHeaderFilter(ILogger<ResponseHeaderFilter> logger, string key, string value)
	{
        this._logger = logger;
        this._key = key;
        this._value = value;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("{FilterName}:{MethodName}", nameof(ResponseHeaderFilter), nameof(OnActionExecuted));
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("{FilterName}:{MethodName}", nameof(ResponseHeaderFilter), nameof(OnActionExecuting));
        context.HttpContext.Response.Headers[_key] = _value;
    }
}

