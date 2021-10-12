using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API
{
  [Migration(2)]
  public class AddCidade : Migration
  {
    public override void Down()
    {
      throw new NotImplementedException();
    }

    public override void Up()
    {
      Create.Table("Cidade")
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("Nome").AsString(50).NotNullable()
        .WithColumn("EstadoId").AsInt64().NotNullable().ForeignKey("Estado", "Id");

      Create.Index("FK_Cidade_Estado")
                .OnTable("Cidade")
                .OnColumn("EstadoId")
                .Ascending()
                .WithOptions().NonClustered();
    }
  }
}
