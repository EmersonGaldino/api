using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Repository.Log;
using galdino.funcional.domain.core.Interface.Service.Base;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Log
{
	public interface ILoggerService : IServiceBase<LoggerDomain, ILoggerRepository>
	{
		void SaveLoggerSuccess(LoggerDomain model);
	}
}
