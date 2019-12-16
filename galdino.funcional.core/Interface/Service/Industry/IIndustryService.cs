using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.core.Interface.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Service
{
	public interface IIndustryService : IServiceBase<IndustryDomain, IIndustryRepository>
	{
		Task<IList<IndustryDomain>> GetAllIndustry();
	}
}
