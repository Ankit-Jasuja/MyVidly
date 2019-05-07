using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MyVidly
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var result = new HttpResponseMessage
            {
                Content = new StringContent("Unhandled Exception: " + actionExecutedContext.Exception.Message),
                StatusCode = HttpStatusCode.InternalServerError
            };
            actionExecutedContext.Response = result;
        }
    }
}