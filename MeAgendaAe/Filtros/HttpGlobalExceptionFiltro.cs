using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MeAgendaAe.Filtros
{
    public class HttpGlobalExceptionFiltro : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFiltro> logger;

        public HttpGlobalExceptionFiltro(ILogger<HttpGlobalExceptionFiltro> logger)
        {

            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var problemDetails = new ValidationProblemDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Detail = context.Exception.StackTrace,
                Title = "Erro interno no servidor"

            };

            problemDetails.Errors.Add("ServerError", new string[] { "Atualize a página e tente novamente." });

            context.Result = new BadRequestObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;
        }
    }
}
