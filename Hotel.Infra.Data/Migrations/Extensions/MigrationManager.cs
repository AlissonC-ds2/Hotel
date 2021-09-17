using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Migrations.Extensions
{
  public static class MigrationManager
  {

    public static IHost MigrateDatabase(this IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var databaseService = scope.ServiceProvider.GetRequiredService<DataBase>();
        try
        {
          databaseService.CreateDatabase("DapperMigrationExample");
        }
        catch
        {
          throw;
        }
      }
      return host;
    }

  }
}
