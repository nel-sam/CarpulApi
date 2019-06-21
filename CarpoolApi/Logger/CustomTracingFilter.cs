using Microsoft.AspNetCore.Mvc.Filters;
using OpenTracing.Util;

namespace CarpoolApi.Api.Logger
{
    public class CustomTracingFilter : ActionFilterAttribute
    {
        /// <summary>
        /// This implementation uses MVC APIs so needs to reside in the API project
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"].ToString();
            GlobalTracer.Instance.BuildSpan(controller).StartActive();
        }

        /// <summary>
        /// Cleans up the tracer by closing it. This makes it act as if it were all done within
        /// a using statement, which is the pattern you see in most OpenTrace examples
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var scope = GlobalTracer.Instance.ScopeManager.Active;

            if (scope?.Span != null)
            {
                scope.Span.Finish();
            }

            base.OnActionExecuted(context);
        }
    }
}
