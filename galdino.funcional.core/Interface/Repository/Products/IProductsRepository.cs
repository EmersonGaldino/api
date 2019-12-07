using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Interface.Repository.Products
{
	public interface IProductsRepository : IRepositoryBase<ProductsDomain>
	{
		Task<IList<ProductsDomain>> GetAllProductsAsync();
		Task<IList<ProductsDomain>> GetProductsByIndustryAsync(ProductsDomain model);
	}
}
