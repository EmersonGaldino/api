using galdino.funcional.application_2.Service.AppServicecBase;
using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.core.Interface.Service;

namespace galdino.funcional.application.Interface.Service.Industry
{
	public interface IIndustryAppService : IAppServiceBase<IndustryDomain, IIndustryService, IIndsutryRepository>
	{
	}
}
