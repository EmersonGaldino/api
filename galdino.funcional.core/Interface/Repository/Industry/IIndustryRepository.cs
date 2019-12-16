using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Repository.Industry
{
	public interface IIndustryRepository : IRepositoryBase<IndustryDomain>
	{
		Task<IList<IndustryDomain>> GetAllIndustry();
	}
}
