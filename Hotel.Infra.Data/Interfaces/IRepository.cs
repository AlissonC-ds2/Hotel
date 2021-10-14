using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Interfaces
{
  public interface IRepository
  {
    void BeginTransaction();
    Task Commit();
    Task Rollback();
    void CloseTransaction();
    Task Save<T>(T entity);
    Task Delete<T>(T entity);
  }
}
