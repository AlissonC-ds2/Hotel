using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API
{
  [Migration(3)]
  public class AddEstado : Migration
  {
    public override void Down()
    {
      throw new NotImplementedException();
    }

    public override void Up()
    {
      Create.Table("Estado")
      .WithColumn("Id").AsInt64().PrimaryKey().Identity()
      .WithColumn("Nome").AsString(50).NotNullable()
      .WithColumn("Sigla").AsString(50).NotNullable();
      
    }
  }
}
