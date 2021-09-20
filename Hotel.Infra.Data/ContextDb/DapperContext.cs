using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Hotel.Infra.Data.ContextDb
{
  public class DapperContext
  {
    private readonly IConfiguration _configuration;
    private readonly string connectionString;
    private readonly string masterConnectionString;

    public DapperContext(IConfiguration configuration)
    {
      _configuration = configuration;
      masterConnectionString = _configuration.GetConnectionString("MasterConnection");
      connectionString = _configuration.GetConnectionString("SqlConnection");
    }


    public IDbConnection CreateConnection()
        => new SqlConnection(connectionString);
    public IDbConnection CreateMasterConnection()
        => new SqlConnection(masterConnectionString);
  }


}
