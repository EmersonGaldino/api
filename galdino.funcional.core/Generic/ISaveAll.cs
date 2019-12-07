using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Generic
{
	public interface ISaveAll<T> where T : class
	{
		Task SaveAsync(IList<T> entities);
	}
}
