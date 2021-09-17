using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace Hotel.Infra.Data.ContextDb
{
  public class DapperContext
  {

    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperContext(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("MyConnectionString");
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);

    public IDbConnection CreateMasterConnection()
        => new NpgsqlConnection(_configuration.GetConnectionString("MasterConnection"));
  }
}
