using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.domain.core.Entity.Products;
using System.ComponentModel.DataAnnotations;

namespace galdino.funcional.api.Models.ViewModel.Products
{
	public class ProductsViewModel : IViewModel<ProductsDomain>
	{
		/// <summary>
		/// Insira um parametro para busca, parametro esperado nome da Industria 
		/// </summary>
		/// <example>meu.usuario</example>
		[Required]
		public string Industry { get; set; }
	}
}
