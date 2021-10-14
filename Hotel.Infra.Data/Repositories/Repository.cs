using Hotel.Infra.Data.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Repositories
{
  public class Repository : IRepository
  {
    private ISession _session;
    private ITransaction _transaction;

    public Repository(ISession session) => _session = session;

    //Note que nas operações que realizam alterações no banco, é criada uma transação:
    //Isso não é necessário, mas é recomendado que seja implementado. Assim, caso ocorra um erro durante
    //a alteração, é possível voltar o banco para o estado anterior a transação:

    public void BeginTransaction()
    {
      _transaction = _session.BeginTransaction();
    }

    public void CloseTransaction()
    {
      if (_transaction != null)
      {
        _transaction.Dispose();
        _transaction = null;
      }
    }

    public async Task Commit()
    {
      await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
      await _transaction.RollbackAsync();
    }

    public async Task Save<T>(T entity)
    {
      await _session.SaveOrUpdateAsync(entity);
    }

    public async Task Delete<T>(T entity)
    {
      await _session.DeleteAsync(entity);
    }
  }
}
