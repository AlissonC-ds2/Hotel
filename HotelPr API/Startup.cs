using AutoMapper;
using FluentMigrator.Runner;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Profiles;
using Hotel.Infra.Data.ContextDb;
using Hotel.Infra.Data.Migrations.Extensions;
using Hotel.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelPr_API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<DapperContext>();
      services.AddSingleton<DataBase>();


      //Fazendo a injeção de depêndencia dos repository
      services.AddScoped<IRepository, Repository>();

      services.AddFluentMigratorCore()
              .ConfigureRunner(c => c.AddSqlServer2016()
              .WithGlobalConnectionString(Configuration.GetConnectionString("SqlConnection"))
              .ScanIn(Assembly.GetExecutingAssembly()).For.All())
            .AddLogging(config => config.AddFluentMigratorConsole());


      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
      });


      //services.AddAutoMapper(Assembly.GetExecutingAssembly());


      // Verificar se funciona o método acima ^
      var configuration = new MapperConfiguration(cfg => cfg.AddMaps("Hotel.Domain"));

      IMapper mapper = configuration.CreateMapper();

      services.AddSingleton(mapper);

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelPr_API", Version = "v1" });
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelPr_API v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(options => options.AllowAnyOrigin());

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      
    }
  }
}
