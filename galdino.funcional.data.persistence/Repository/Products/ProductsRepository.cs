using Dapper;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.Products;
using galdino.funcional.domain.core.Interface.Repository.Products;
using galdino.funcional.domain.shared.Interfaces.Connections;
using System.Collections.Generic;
using System.Text;
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

		public async Task<IList<ProductsDomain>> GetProductsByIndustryAsync(string model)
		{
			var data = await Uow.GetConnection()
				.QueryAsync<ProductsDomain>("SELECT * FROM tb_produto prod " +
					"INNER JOIN tb_industry ind ON prod.industry_id = ind.industry_id " +
					$"WHERE ind.str_name = '{model.ToLower()}'", Uow.GetTransaction());
			return data.AsList();
		}

		public async Task<ProductsDomain> ProductyUpdateAsync(ProductsDomain data)
		{

			return await Uow.GetConnection()
				.QueryFirstAsync<ProductsDomain>("UPDATE tb_produto " +
				$" SET  str_name ='{data.Product}', d_price ='{data.Price}'," +
				$" dh_datechangeregistration ='now()'," +
				$" active ={data.Active} WHERE product_id ={data.Product_id} returning *", Uow.GetTransaction());

			 
		}

		public async Task<IList<ProductsDomain>> ProductyCreateAsync(IList<ProductsDomain> data)
		{
			var sql = new StringBuilder();
			foreach(var item in data)
			{
				sql.AppendLine("INSERT INTO tb_produto( " +
				" str_name, industry_id, d_price, amount, dh_dateinclusionregistration, active)" +				
				$" VALUES ( '{item.Product}', {item.industryId}, {item.Price}, {item.Amount}, 'now()', {item.Active}) returning * ;");
			};
			var result = await Uow.GetConnection()
				.QueryAsync<ProductsDomain>(sql.ToString(), Uow.GetTransaction());
			return result.AsList();
		}

		public async Task<bool> ProductyDeleteAsync(int model)
		{
			await Uow.GetConnection()
				.QueryFirstOrDefaultAsync<bool>($"DELETE FROM tb_produto WHERE product_id = {model}; ", Uow.GetTransaction());

			return true;
		}

		#endregion


	}
}
