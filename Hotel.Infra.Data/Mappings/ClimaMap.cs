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
  public class ClimaMap : ClassMap<Clima>
  {
    public ClimaMap()
    {
      Table("Clima");

      Id(x => x.Id);
      Map(x => x.Data).Not.Nullable();
      Map(x => x.Temperatura).Not.Nullable().Length(12);
      Map(x => x.TemperaturaMaxima).Not.Nullable().Length(12);
      Map(x => x.TemperaturaMinima).Not.Nullable().Length(12);
      Map(x => x.Descricao).Not.Nullable().Length(100);
      Map(x => x.Umidade).Length(6);
      Map(x => x.Velocidade).Length(12);
      Map(x => x.PressaoAtm).Length(12);
      Map(x => x.TipoClima).CustomType<ETipoClima>();


      References(x => x.Cidade);
    }
  }
}
