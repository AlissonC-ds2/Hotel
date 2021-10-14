using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using Hotel.Infra.Data.Mappings;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Extensions
{
  public static class NHibernateExtensions
  {
    public static IServiceCollection AddNHibernate(this IServiceCollection services,
    string connectionString)
    {
      var sessionfactory = Fluently.Configure()
      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
      .Mappings(m =>
        m.FluentMappings.AddFromAssemblyOf<EstadoMap>())
      .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                                              .Execute(false, true))
      .BuildSessionFactory();


      services.AddSingleton(sessionfactory);
      services.AddScoped(factory => sessionfactory.OpenSession());

      return services;
    }
  }
}
