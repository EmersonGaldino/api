using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.core.Interface.Service.Base;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Service.User
{
	public interface IUserService : IServiceBase<UserDomain, IUserRepository>
	{
		Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel);
	}
}
