using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.core.Interface.Service;
using galdino.funcional.domain.core.Service.Base;

namespace galdino.funcional.domain.core.Service.Industry
{
	public class IndustryService : ServiceBase<IndustryDomain, IIndsutryRepository>, IIndustryService
	{
		#region .::Contructor
		public IndustryService(IIndsutryRepository repository) : base(repository)
		{

		} 
		#endregion
	}
}
