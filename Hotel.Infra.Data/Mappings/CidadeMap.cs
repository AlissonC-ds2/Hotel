using FluentNHibernate.Mapping;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Mappings
{
  public class CidadeMap : ClassMap<Cidade>
  {
    public CidadeMap()
    {
      Id(x => x.Id);
      Map(x => x.Nome).Not.Nullable().Length(50);
      
      
      References(x => x.Estado);

      Table("Cidade");
    }
  }
}
