using MeAgendaAe.Dominio.Enums;
using MeAgendaAe.Dominio.Validacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;

namespace MeAgendaAe.Filtros
{
    public class DominioValidacaoFiltro : IAsyncResultFilter
    {

        private readonly IDominioValidacaoService _dominioValidacaoService;

        public DominioValidacaoFiltro(IDominioValidacaoService dominioValidacaoService)
        {
            _dominioValidacaoService = dominioValidacaoService;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_dominioValidacaoService.Retorno == TipoRetorno.NotFound)
            {
                var problemDetalhes = new ValidationProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status404NotFound,
                    Detail = "NotFoundException",
                    Title = "Não encontrado"
                };

                context.Result = new NotFoundObjectResult(problemDetalhes);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (_dominioValidacaoService.Retorno == TipoRetorno.BadRequest)
            {
                var problemDetalhes = new ValidationProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Consulte a propriedade de erros para obter detalhes adicionais.",
                    Title = "Problema com as Validações"
                };

                problemDetalhes.Errors.Add("ValidacoesDominio", _dominioValidacaoService.Mensagens);

                context.HttpContext.Response.ContentType = "application/json";

                context.Result = new BadRequestObjectResult(problemDetalhes);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            await next();
        }
    }
}
