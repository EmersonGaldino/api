using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace galdino.funcional.domain.core.Entity.Log
{
	[Table("tb_requestLog")]
	public class LoggerDomain
	{
		[Column("object")]
		public string objects { get; set; }
		[Column("user_id")]
		public int userId { get; set; }
		[Column("token")]
		public string token { get; set; }
		[Column("dh_dateinclusionregistration")]
		public DateTime Include { get; set; }
	}
}
