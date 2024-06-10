using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CountryService.Helper
{
    public class DefaultExceptionFilter : IExceptionHandler
    {
        public DefaultExceptionFilter() { }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = "An unSpecified error / runtime",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method}{httpContext.Request.Path}"
            });

            string error = $"{httpContext.Request.Method}{httpContext.Request.Path}" + exception.Message;
            WriteExceptionLog(error, @"E:\Coreco\CountryService\CountryService\error-log");

            return true;
        }
        private void WriteExceptionLog(string errroMessage, string fileName)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(errroMessage);
            }
        }
        private void InsertErrorLog(string errroMessage, string fileName)
        {
            //DB logoc
        }
    }
}
