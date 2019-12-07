using galdino.funcional.application_2.Service.AppServicecBase;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.core.Interface.Service.User;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace galdino.funcional.application_2.Interface.Service.User
{
	public interface IUserAppService : IAppServiceBase<UserDomain, IUserService, IUserRepository>
	{
		void ValidarTipoAcessoUsuarioAsync(ActionExecutingContext context);
		Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel);
	}
}
