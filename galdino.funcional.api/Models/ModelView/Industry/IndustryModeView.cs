using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.domain.core.Entity.Industry;

namespace galdino.funcional.api.Models.ModelView.Industry
{
	public class IndustryModeView : IModelView<IndustryDomain>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
}
