using Dapper;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.shared.Interfaces.Connections;
using System.Threading.Tasks;

namespace galdino.funcional.data.persistence.Repository.User
{
	public class UserRepository : RepositoryBase<UserDomain>, IUserRepository
	{
		#region .::Constructor
		public IConnectionFuncional Uow { get; set; }
		public UserRepository(IConnectionFuncional uow) : base(uow)
		{
			Uow = uow;
		}
		public IConnectionFuncional getUow() { return Uow; }
		#endregion

		#region .::Methods
		public async Task<UserDomain> ValidarUsuarioAsync(UserDomain viewModel)
		{
			try
			{
				var query = $@"SELECT {GetFields()} FROM {GetTableName()} 
				         WHERE str_login = @Login
				         and str_password = @Password 
				         LIMIT 1";
				return await Uow.GetConnection()
					.QueryFirstOrDefaultAsync<UserDomain>(query,
						new
						{
							viewModel.Login,
							viewModel.Password,
						}, Uow.GetTransaction());
				
			}
			finally
			{
				Uow.Release();
			}
		}
		#endregion
	}
}
