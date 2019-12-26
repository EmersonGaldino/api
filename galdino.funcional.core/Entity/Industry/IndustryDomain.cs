using galdino.funcional.domain.core.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace galdino.funcional.domain.core.Entity.Industry
{
	[Table("tb_industry")]
	public class IndustryDomain : BaseEntity
	{
		[Column("industry_id")]
		public int Id { get; set; }
		[Column("str_name")]
		public string Name { get; set; }
		[Column("active")]
		public bool Active { get; set; }
	}
}
