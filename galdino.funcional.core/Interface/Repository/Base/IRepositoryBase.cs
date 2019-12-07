using galdino.funcional.domain.core.Generic;

namespace galdino.funcional.domain.core.Interface.Repository.Base
{
	public interface IRepositoryBase<T> : IGet<T>,
		ISelect<T>, IListByIds<T>, IGetUow, ISave<T>, ISaveAll<T> where T : class
	{
	}
}
