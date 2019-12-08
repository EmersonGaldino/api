using galdino.funcional.application_2.Service.AppServicecBase;
using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.core.Interface.Service.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.application.Interface.Service.Products
{
	public interface IProductsAppService : IAppServiceBase<ProductsDomain, IProductsService, IProductsRepository>
	{
		Task<IList<ProductsDomain>> GetAllProductsAsync();
		Task<IList<ProductsDomain>> GetProductsByIndustryAsync(string model);
		Task<ProductsDomain> ProductyUpdateAsync(ProductsDomain data);
		Task<IList<ProductsDomain>> ProductyCreateAsync(IList<ProductsDomain> data);
		Task<bool> ProductyDeleteAsync(int model);
	}
}
