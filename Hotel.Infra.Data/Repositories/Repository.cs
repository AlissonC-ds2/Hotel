using AutoMapper;
using Dapper;
using Hotel.Domain;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Hotel.Infra.Data.ContextDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Repositories
{
  public class Repository : IRepository
  {
    private readonly DapperContext _context;

    public Repository(DapperContext context)
    {
      _context = context;
    }

    public async void Post(string query, DynamicParameters parameters)
    {

      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, parameters);

        connection.Dispose();
      }

    }


    public void Delete<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel
    {
      throw new NotImplementedException();
    }

    public void Put<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel
    {
      throw new NotImplementedException();
    }

    public List<T> GetAll<T>(string sql)
    {
      
      using (var connection = _context.CreateConnection())
      {
        return connection.Query<T>(sql).ToList();
      }


    }
  }
}
