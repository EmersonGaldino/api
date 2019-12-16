using Dapper;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.Industry;
using galdino.funcional.domain.core.Interface.Repository.Industry;
using galdino.funcional.domain.shared.Interfaces.Connections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace galdino.funcional.data.persistence.Repository.Industry
{
	public class IndustryRepository : RepositoryBase<IndustryDomain>, IIndustryRepository
	{
		#region .::Constructor
		private IConnectionFuncional Uow { get; set; }
		public IndustryRepository(IConnectionFuncional uow) : base(uow)
		{
			Uow = uow;
		}
		public IConnectionFuncional getUow() { return Uow; }

		#endregion

		public async Task<IList<IndustryDomain>> GetAllIndustry()
		{
			var data = await Uow.GetConnection()
				.QueryAsync<IndustryDomain>($"SELECT {GetFields()} FROM {GetTableName()} ORDER BY 1", Uow.GetTransaction());
			var list = data.AsList();
			return list;
		}
	}
}
