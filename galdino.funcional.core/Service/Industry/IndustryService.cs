using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.core.Interface.Service;
using galdino.funcional.domain.core.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Service.Industry
{
	public class IndustryService : ServiceBase<IndustryDomain, IIndustryRepository>, IIndustryService
	{
		#region .::Contructor
		public IndustryService(IIndustryRepository repository) : base(repository)
		{

		}
		#endregion

		#region .::Mehtods
		public async Task<IList<IndustryDomain>> GetAllIndustry() =>
			await GetRepository().GetAllIndustry(); 
		#endregion



	}
}
