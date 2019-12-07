using System;
using System.Collections.Generic;
using System.Text;

namespace galdino.funcional.domain.shared.Configurations.Token
{
	public class TokenConfigurations
	{
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public int ExpireIn { get; set; }
		public string SigningKey { get; set; }
	}
}
