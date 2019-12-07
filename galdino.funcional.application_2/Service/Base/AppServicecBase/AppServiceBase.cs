using galdino.funcional.application_2.Service.AppServicecBase;
using galdino.funcional.domain.core.Interface.Repository.Base;
using galdino.funcional.domain.core.Interface.Service.Base;

namespace galdino.funcional.application_2.Service.Base.AppServicecBase
{
	public class AppServiceBase<T, S, R> : IAppServiceBase<T, S, R>
		where T : class
		where S : IServiceBase<T, R>
		where R : IRepositoryBase<T>
	{
		protected readonly IServiceBase<T, R> _service;

		public AppServiceBase(IServiceBase<T, R> serviceBase)
		{
			_service = serviceBase;
		}

		public S GetService() => (S)_service;
	}
}

