using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace NewBook.Api.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger) => _logger = logger;

        public Task OnExceptionAsync(ExceptionContext context)
        {
            ObjectResult result = new ObjectResult(new ExceptionModel()
            {
                message = context.Exception.Message,
                detail = context.Exception.Message,
                code = Convert.ToInt32(context.Exception.Data["status_code"]),
                error = true
            })
            {
                StatusCode = Convert.ToInt32(context.Exception.Data["status_code"])
            };
            context.Result = result;

            _logger.LogError($"Unhandled exception occurred while executing request: {context.Exception.Message}", context.Exception);
            return Task.CompletedTask;
        }
    }
}