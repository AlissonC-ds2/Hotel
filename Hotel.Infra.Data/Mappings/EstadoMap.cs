using FluentNHibernate.Mapping;
using Hotel.Domain.Entities;
using Hotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Mappings
{
  public class EstadoMap : ClassMap<Estado>
  {
    public EstadoMap() 
    {
      Id(x => x.Id);
      Map(x => x.Nome).Not.Nullable().Length(50);
      Map(x => x.Sigla).CustomType<EstadoSiglaEnum>();

      Table("Estado");
    }

  }
}
