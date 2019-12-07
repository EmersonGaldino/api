using System.Threading.Tasks;

namespace galdino.funcional.domain.core.Generic
{
	public interface ISave<T> where T : class
	{
		Task SaveAsync(T entities);
	}
}
