using Dapper;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Interface.Repository.Log;
using galdino.funcional.domain.shared.Interfaces.Connections;

namespace galdino.funcional.data.persistence.Repository.Log
{
	public class LoggerRepository : RepositoryBase<LoggerDomain>, ILoggerRepository
	{
		#region .::Constructor
		private IConnectionFuncional Uow { get; set; }
		public LoggerRepository(IConnectionFuncional uow) : base(uow)
		{
			Uow = uow;
		}
		public IConnectionFuncional getUow() { return Uow; }
		#endregion

		#region .::Methods
		public async void SaveLogger(LoggerDomain model)
		{
			await Uow.GetConnection()
			   .ExecuteAsync($"INSERT INTO tb_requestlog(" +
			   $" object, user_id, dh_dateinclusionregistration) " +
			   $"VALUES( '{model.objects}', {model.userId}, 'now()'); ", Uow.GetTransaction());
		} 
		#endregion

	}
}
