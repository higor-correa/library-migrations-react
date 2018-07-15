using Library.Bll.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Library.Api.ExceptionsHandler
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            dynamic message = null;
            var code = HttpStatusCode.InternalServerError;

            if (exception is EntityNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is BusinessException) code = HttpStatusCode.BadRequest;

            if (code == HttpStatusCode.InternalServerError)
                message = new { message = "Ocorreu um erro interno do servidor, contate o suporte ou tente novamente mais tarde.", realException = exception.Message };
            else
                message = new { message = exception.Message };

            var result = JsonConvert.SerializeObject((object)message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
