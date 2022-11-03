﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace MeAgendaAe.Filtros
{
    public class ValidarModelStateFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid || !context.HttpContext.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                return;
            }

            var validationErrors = context.ModelState
               .Keys
               .SelectMany(k => context.ModelState[k].Errors)
               .Select(e => e.ErrorMessage)
               .ToArray();

            var problemDetails = new ValidationProblemDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest,
                Detail = "Consulte a propriedade de erros para obter detalhes adicionais.",
                Title = "Problema com as validações"

            };

            problemDetails.Errors.Add("ValidacoesDominio", validationErrors);

            context.Result = new BadRequestObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
