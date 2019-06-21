using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using OpenTracing.Util;
using System.Collections.Generic;

namespace CarpoolApi.Api
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // The log gets associated with the Controller that threw the exception
            var controller = context.RouteData.Values["controller"].ToString();
            var action = context.RouteData.Values["action"].ToString();

            using (var scope = GlobalTracer.Instance.BuildSpan(controller).StartActive())
            {
                scope.Span.Log(new Dictionary<string, object>
                {
                    { "LogLevel", LogLevel.Error },
                    { "Controller", controller },
                    { "Action", action},
                    { "Exception", context.Exception }
                });
            }
        }
    }
}
