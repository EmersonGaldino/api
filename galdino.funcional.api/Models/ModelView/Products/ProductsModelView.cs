using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.domain.core.Entity.Products;

namespace galdino.funcional.api.Models.ModelView.Products
{
	public class ProductsModelView : IModelView<ProductsDomain>
	{
		public string Product { get; set; }
		public int Product_id { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }
		public bool Active { get; set; }
	}
}
