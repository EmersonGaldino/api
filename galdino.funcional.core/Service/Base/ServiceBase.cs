using galdino.funcional.domain.core.Interface.Repository.Base;
using galdino.funcional.domain.core.Interface.Service.Base;

namespace galdino.funcional.domain.core.Service.Base
{
    public class ServiceBase<T, R> : IServiceBase<T, R>
		where T : class
		where R : IRepositoryBase<T>
	{
        #region Constructor
        protected readonly IRepositoryBase<T> repositoryBase;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            repositoryBase = repository;
        }
        #endregion

        #region Methods
        public R GetRepository() => (R)repositoryBase;

        #endregion
    }
}
