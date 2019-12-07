using galdino.funcional.domain.core.Generic;
using galdino.funcional.domain.core.Interface.Repository.Base;

namespace galdino.funcional.domain.core.Interface.Service.Base
{
	public interface IServiceBase<T, R> : IGet<T>, ISelect<T> where T : class where R : IRepositoryBase<T>
	{
		R GetRepository();
	}
}
