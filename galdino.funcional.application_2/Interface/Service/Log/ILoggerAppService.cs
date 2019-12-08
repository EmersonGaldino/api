using galdino.funcional.application_2.Service.AppServicecBase;
using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Log;
using galdino.funcional.domain.core.Interface.Repository.Log;
using System.Threading.Tasks;

namespace galdino.funcional.application.Interface.Service.Log
{
	public interface ILoggerAppService : IAppServiceBase<LoggerDomain, ILoggerService, ILoggerRepository>
	{
		void SaveLogger(LoggerDomain model);
		
	}
}
