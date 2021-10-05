using Dapper;
using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
  public interface IRepository
  {
    List<T> GetAll<T>(string sql);

    void Post(string query, DynamicParameters parameters);

    void Delete<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel;

    void Put<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel;

  }
}
