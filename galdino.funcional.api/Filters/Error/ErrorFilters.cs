using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.api.Security;
using galdino.funcional.domain.core.Exception.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace galdino.funcional.api.Filters.Error
{
    public class ErrorFilters : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var coreError = context.Exception is DomainException;
            var mvcController = context.ActionDescriptor.RouteValues["controller"];
            var mvcAction = context.ActionDescriptor.RouteValues["action"];
            var errorMessage = $"{context.Exception.Message} {context.Exception.InnerException?.Message}";
            var result = new BaseViewModel<ErroViewModel>
            {

                Sucesso = false,
                ObjetoDeRetorno = new ErroViewModel()
                {
                    Core = coreError,
                    Controller = mvcController,
                    Action = mvcAction,
                    Mensagem = errorMessage
                },

            };
            context.Result = new InternalServerErrorObjectResult(result);
        }
    }
}
