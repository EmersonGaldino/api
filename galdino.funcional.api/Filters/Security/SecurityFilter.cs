using galdino.funcional.application_2.Interface.Service.User;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace galdino.funcional.api.Filters.Security
{
    public class SecurityFilter : IAsyncActionFilter
    {
        private readonly IUserAppService _usuarioAppService;
        public SecurityFilter(

            IUserAppService usuarioAppService)
        {

            _usuarioAppService = usuarioAppService;
        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                _usuarioAppService.ValidarTipoAcessoUsuarioAsync(context);
            }
            return next();
        }
    }
}
