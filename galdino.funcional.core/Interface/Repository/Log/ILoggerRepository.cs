using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Repository.Base;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Repository.Log
{
	public interface ILoggerRepository : IRepositoryBase<LoggerDomain>
	{
		void SaveLogger(LoggerDomain model);
	}
}
