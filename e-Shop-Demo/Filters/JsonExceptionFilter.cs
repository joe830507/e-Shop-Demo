using e_Shop_Demo.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace e_Shop_Demo.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public IWebHostEnvironment Environment { get; }
        public ILogger<Program> Logger { get; }
        public JsonExceptionFilter(IWebHostEnvironment env, ILogger<Program> logger)
        {
            Environment = env;
            Logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();
            if (Environment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.ToString();
            }
            else
            {
                error.Message = "Server Error";
                error.Detail = context.Exception.Message;
            }
            context.Result = new ObjectResult(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Server Error:{context.Exception.Message}");
            sb.AppendLine(context.Exception.ToString());
            Logger.LogCritical(sb.ToString());
        }
    }
}
