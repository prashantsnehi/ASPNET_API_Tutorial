using System;
using Microsoft.AspNetCore.Mvc.Filters;
namespace API_Tutorial.Filters;


public class ResponseHeaderFilter : IActionFilter, IOrderedFilter
{
	private readonly ILogger<ResponseHeaderFilter> _logger;
    private readonly string _key;
    private readonly string _value;

    public ResponseHeaderFilter(ILogger<ResponseHeaderFilter> logger, string key, string value, int order)
	{
        this._logger = logger;
        this._key = key;
        this._value = value;
        this.Order = order;
    }

    public int Order { get; set; }

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

