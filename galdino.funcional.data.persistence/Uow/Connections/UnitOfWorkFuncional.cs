using galdino.funcional.domain.shared.Interfaces.Connections;

namespace galdino.funcional.data.persistence.Uow.Connections
{
	public class UnitOfWorkFuncional : UnitOfWork , IConnectionFuncional 
	{
		public UnitOfWorkFuncional(string connectionString) : base(connectionString)
		{

		}
	}
}
