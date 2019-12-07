using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.core.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Service.Products
{
	public interface IProductsService : IServiceBase<ProductsDomain, IProductsRepository>
	{
		Task<IList<ProductsDomain>> GetAllProductsAsync();
		Task<IList<ProductsDomain>> GetProductsByIndustryAsync(ProductsDomain model);
	}
}
