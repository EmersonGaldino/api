using Dapper;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.shared.Interfaces.Connections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.data.persistence.Repository.Products
{
	public class ProductsRepository : RepositoryBase<ProductsDomain>, IProductsRepository
	{
		#region Constructor
		private IConnectionFuncional Uow { get; set; }
		public ProductsRepository(IConnectionFuncional uow) : base(uow)
		{
			Uow = uow;
		}
		public IConnectionFuncional getUow() { return Uow; }

		#endregion

		#region Methods
		public async Task<IList<ProductsDomain>> GetAllProductsAsync()
		{
			var data = await Uow.GetConnection()
				.QueryAsync<ProductsDomain>($"SELECT {GetFields()} FROM {GetTableName()}", Uow.GetTransaction());
			var list = data.AsList();
			return list;
		}

		public async Task<IList<ProductsDomain>> GetProductsByIndustryAsync(ProductsDomain model)
		{			
			var data = await Uow.GetConnection()
				.QueryAsync<ProductsDomain>("SELECT * FROM tb_produto prod " +
					"INNER JOIN tb_industry ind ON prod.industry_id = ind.industry_id " +
					$"WHERE ind.str_name = '{model.Industry.ToLower()}'", Uow.GetTransaction());
			return data.AsList();
		}
		#endregion


	}
}
