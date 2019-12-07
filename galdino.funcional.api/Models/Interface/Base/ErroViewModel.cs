using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace galdino.funcional.api.Models.Interface.Base
{
	public class ErroViewModel
	{
		public bool Core { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }
		public string Mensagem { get; set; }
	}
}
