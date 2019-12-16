using galdino.funcional.application.Interface.Service.Industry;
using galdino.funcional.application_2.Service.Base.AppServicecBase;
using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace galdino.funcional.application.Service.Industry
{
	public class IndustryAppService : AppServiceBase<IndustryDomain, IIndustryService, IIndustryRepository>, IIndustryAppService
	{
		#region .::Constructor
		public IndustryAppService(IIndustryService service) : base(service)
		{

		}
		#endregion

		#region .::Methods
		public async Task<IList<IndustryDomain>> GetAllIndustry() =>
			await GetService().GetAllIndustry();

		#endregion
	}
}
