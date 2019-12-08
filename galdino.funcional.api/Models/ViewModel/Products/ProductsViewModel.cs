using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.domain.core.Entity.Products;

namespace galdino.funcional.api.Models.ViewModel.Products
{
	public class ProductsViewModel : IViewModel<ProductsDomain>
	{
		/// <summary>
		/// Nome do produto que deseja alterar.
		/// </summary>
		/// <example>Fralda pampers</example>		
		public string Product { get; set; }

		/// <summary>
		/// Valor do produto.
		/// </summary>
		/// <example>11.50</example>		
		public string Price { get; set; }
		
		/// <summary>
		/// Se o produto esta disponivel ou não.
		/// </summary>
		/// <example>true/false</example>		
		public bool Active { get; set; }

		/// <summary>
		/// Id do produto que deseja alterar.
		/// </summary>
		/// <example>150</example>		
		public int Product_id { get; set; }

		/// <summary>
		/// Id da industria que pertence este produto.
		/// </summary>
		/// <example>1</example>		
		public int ndustryId { get; set; }

		/// <summary>
		/// Quantidade do produto em estoque.
		/// </summary>
		/// <example>1</example>		
		public int amount { get; set; }
	}
}
