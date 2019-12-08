using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Log;
using galdino.funcional.domain.core.Interface.Repository.Log;
using galdino.funcional.domain.core.Service.Base;

namespace galdino.funcional.domain.core.Service.Log
{
	public class LoggerService : ServiceBase<LoggerDomain, ILoggerRepository>, ILoggerService
	{
		#region .::Constructor
		public LoggerService(ILoggerRepository repository) : base(repository)
		{

		}

		#endregion

		#region .::Methods
		public async void SaveLogger(LoggerDomain model) =>
		 GetRepository().SaveLogger(model);
		#endregion
	}
}
