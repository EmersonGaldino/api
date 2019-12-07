using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.core.Interface.Service.Products;
using galdino.funcional.domain.core.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Service.Products
{
	public class ProductsService : ServiceBase<ProductsDomain,IProductsRepository>,IProductsService
	{
		#region Constructor
		public ProductsService(IProductsRepository repository) : base(repository)
		{

		}
		#endregion

		#region Methods
		public async Task<IList<ProductsDomain>> GetAllProductsAsync() =>
			await GetRepository().GetAllProductsAsync();

		public async Task<IList<ProductsDomain>> GetProductsByIndustryAsync(ProductsDomain model) =>
			await GetRepository().GetProductsByIndustryAsync(model);

		#endregion
	}
}
