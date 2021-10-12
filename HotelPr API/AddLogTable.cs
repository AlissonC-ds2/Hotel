using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPr_API
{

  [Migration(202106280001)]
  public class AddLogTable : Migration
  {
    public override void Down()
    {
      Delete.Table("Cliente");
    }

    public override void Up()
    {
      Create.Table("Cliente")
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("Nome").AsString(50).NotNullable()
        .WithColumn("DataNasc").AsDateTime().Nullable()
        .WithColumn("Endereco").AsString(50).Nullable()
        .WithColumn("Nacionalidade").AsString(50).NotNullable()
        .WithColumn("Cidade").AsString(50).NotNullable();
    }


  }
}
