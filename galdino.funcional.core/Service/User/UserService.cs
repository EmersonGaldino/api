using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.core.Interface.Service.User;
using galdino.funcional.domain.core.Service.Base;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Service.User
{
	public class UserService : ServiceBase<UserDomain, IUserRepository>, IUserService
	{
		#region .::Constructor
		public UserService(IUserRepository userRepository) : base(userRepository)
		{

		}
		#endregion

		#region .::Methods
		public async Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel) =>
			await GetRepository().ValidarUsuarioAsync(viewModel);
		
		#endregion
	}
}
