using galdino.funcional.application_2.Interface.Service.User;
using galdino.funcional.application_2.Service.Base.AppServicecBase;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.core.Interface.Service.User;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace galdino.funcional.application.Service
{
	public class UserAppService : AppServiceBase<UserDomain, IUserService, IUserRepository>, IUserAppService
	{
		#region .::Constructor
		public UserAppService(IUserService userService) : base(userService)
		{

		}
		#endregion

		#region .::Methods
		public void ValidarTipoAcessoUsuarioAsync(ActionExecutingContext context)
		{
			
		}

		public async Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel) =>
			await GetService().ValidarUsuarioAsync(viewModel); 
		#endregion

	}
}
