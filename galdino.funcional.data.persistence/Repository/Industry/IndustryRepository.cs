using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.shared.Interfaces.Connections;

namespace galdino.funcional.data.persistence.Repository.Industry
{
	public class IndustryRepository : RepositoryBase<IndustryDomain>, IIndsutryRepository
	{
		#region .::Constructor
		private IConnectionFuncional Uow { get; set; }
		public IndustryRepository(IConnectionFuncional uow) : base(uow)
		{
			Uow = uow;
		}
		public IConnectionFuncional getUow() { return Uow; } 
		#endregion
	}
}
