using Dapper;
using Hotel.Infra.Data.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Migrations.Extensions
{
  public class DataBase
  {
    private readonly DapperContext _context;
    public DataBase(DapperContext context)
    {
      _context = context;
    }

    public void CreateDatabase(string dbName)
    {
      var query = "SELECT * FROM sys.databases WHERE name = @name";
      var parameters = new DynamicParameters();
      parameters.Add("name", dbName);
      using (var connection = _context.CreateMasterConnection())
      {
        var records = connection.Query(query, parameters);
        if (!records.Any())
          connection.Execute($"CREATE DATABASE {dbName}");
      }


    }
  }
}
