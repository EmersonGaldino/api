using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace galdino.funcional.domain.core.Entity.Industry
{
	[Table("tb_industry")]
	public class IndustryDomain
	{
		[Column("industry_id")]
		public int Id { get; set; }
		[Column("str_name")]
		public string Name { get; set; }
		[Column("active")]
		public bool Active { get; set; }
	}
}
