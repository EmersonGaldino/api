using galdino.funcional.application_2.Interface.Service.User;
using galdino.funcional.domain.core.Entity.User;
using Xunit;

namespace galdino.funcional.XUnitTest
{

	public class UnitTestUser 
	{
		IUserAppService _usuarioAppService;

		public UnitTestUser(IUserAppService service)
		{
			_usuarioAppService = service;
		}
		[Fact]
		public void Login()
		{
			var user = new UserDomain
			{
				Login = "Galdino",
				Password = "123456"
			};

			var result = _usuarioAppService.ValidarUsuarioAsync(user).GetAwaiter().GetResult();
			var model = Assert.IsType<UserDomain>(result);
		}
	}
}
