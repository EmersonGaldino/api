using System;
using System.Data;

namespace galdino.funcional.domain.shared.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
	{
        void Begin();
        void Commit();
        void RollBack();
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
        void Release();
    }
}
