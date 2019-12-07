using galdino.funcional.domain.shared.Interfaces.IUnitOfWork;

namespace galdino.funcional.domain.core.Generic
{
	public interface IGetUow
	{
		IUnitOfWork GetUow();
	}
}
