using galdino.funcional.application.Interface.Service.Log;
using galdino.funcional.application_2.Service.Base.AppServicecBase;
using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Log;
using galdino.funcional.domain.core.Interface.Repository.Log;
using System.Threading.Tasks;

namespace galdino.funcional.application.Service.Log
{
	public class LoggerAppService : AppServiceBase<LoggerDomain, ILoggerService, ILoggerRepository>, ILoggerAppService
	{
		#region .::Constructor
		public LoggerAppService(ILoggerService service) : base(service)
		{

		}
		#endregion


		#region .::Methods
		public async void SaveLoggerSuccess(LoggerDomain model) =>
			 GetService().SaveLoggerSuccess(model);
		#endregion

	}
}
