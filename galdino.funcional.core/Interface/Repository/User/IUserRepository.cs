using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.Base;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Repository.User
{
	public interface IUserRepository : IRepositoryBase<UserDomain>
	{
		Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel);
		
	}
}
