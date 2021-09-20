﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Migrations
{
  [Migration(202106280001)]
  public class InitialTables_202106280001 : Migration
  {
    public override void Down()
    {
      Delete.Table("Cliente");
    }

    public override void Up()
    {
      Create.Table("Cliente")
        .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
        .WithColumn("Nome").AsString(50).NotNullable()
        .WithColumn("DataNasc").AsDateTime().NotNullable()
        .WithColumn("Endereco").AsString(50)
        .WithColumn("Nacionalidade").AsString(50).NotNullable()
        .WithColumn("Cidade").AsString(50).NotNullable();
    }



  }
}
