using galdino.funcional.domain.core.Interface.Repository.Base;
using galdino.funcional.domain.core.Interface.Service.Base;

namespace galdino.funcional.application_2.Service.AppServicecBase
{
	public interface IAppServiceBase<T, S, R>
		where T : class
		where S : IServiceBase<T, R>
		where R : IRepositoryBase<T>
	{
		S GetService();
	}
}
