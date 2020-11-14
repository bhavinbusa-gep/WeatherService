using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.API
{
    public class RequestHandler
    {
        #region Members

        private readonly RequestDelegate _next;

        #endregion

        #region Constructor
        public RequestHandler(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Invoke

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        #endregion

        #region HandleExceptionAsync

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(exception, true);

            string methodName = stackTrace.GetFrame(0).GetMethod().Name;
            string fullClassName = stackTrace.GetFrame(0).GetMethod().ReflectedType.FullName;
            int lineNumber = stackTrace.GetFrame(0).GetFileLineNumber();
            int statusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(new Models.ErrorDetails
            {
                StatusCode = statusCode,
                Message = exception.Message,
                Stacktrace = GetFullExceptionWithTrace(exception),
                Source = string.Empty
            }.ToString());
        }

        #endregion

        #region GetFullExceptionWithTrace

        private static string GetFullExceptionWithTrace(Exception ex, int level = 0)
        {
            StringBuilder sb = new StringBuilder();
            level++;

            if (ex.InnerException != null)
            {
                sb.AppendLine(GetFullExceptionWithTrace(ex.InnerException, level));
            }

            sb.AppendLine("\n------------- Ex Level: " + (level));
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine();
            string exceptionWithTrace = sb.ToString();
            sb.Clear();
            return exceptionWithTrace;
        }

        #endregion
    }
}
