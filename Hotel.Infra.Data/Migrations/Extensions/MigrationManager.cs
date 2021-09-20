using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        try
        {
          databaseService.CreateDatabase("DapperMigrationExample");

          migrationService.ListMigrations();
          migrationService.MigrateUp();
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
