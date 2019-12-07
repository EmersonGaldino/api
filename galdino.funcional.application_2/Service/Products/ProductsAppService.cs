﻿using galdino.funcional.application.Interface.Service.Products;
using galdino.funcional.application_2.Service.Base.AppServicecBase;
using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.core.Interface.Service.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.application.Service.Products
{
	public class ProductsAppService : AppServiceBase<ProductsDomain, IProductsService, IProductsRepository>, IProductsAppService
	{
		#region Constructor
		public ProductsAppService(IProductsService service) : base(service)
		{

		}
		#endregion

		#region Methods
		public async Task<IList<ProductsDomain>> GetAllProductsAsync() =>
			await GetService().GetAllProductsAsync();

		public async Task<IList<ProductsDomain>> GetProductsByIndustryAsync(ProductsDomain model) =>
			await GetService().GetProductsByIndustryAsync(model);

		#endregion
	}
}
