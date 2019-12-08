using System.ComponentModel.DataAnnotations.Schema;

namespace galdino.funcional.domain.core.Entity.Products
{
	[Table("tb_produto")]
	public class ProductsDomain
	{
		[Column("str_name")]
		public string Product { get; set; }
		[Column("product_id")]
		public int Product_id { get; set; }
		[Column("d_price")]
		public string Price { get; set; }
		[Column("amount")]
		public int Amount { get; set; }
		[Column("active")]
		public bool Active { get; set; }
		public string Industry { get; set; }
		[Column("industry_id")]
		public int industryId { get; set; }
	}
}
