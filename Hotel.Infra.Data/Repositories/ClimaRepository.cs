using Hotel.Domain.Dto;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Repositories
{
  public class ClimaRepository : IClimaRepository
  {
    private readonly ISession _session;

    public ClimaRepository(ISession session)
    {
      _session = session;
    }

    public async Task<List<ClimaDto>> GetAllClimas(long cidadeId)
    {
      Estado estadoAlias = null;
      Cidade cidadeAlias = null;
      Clima climaAlias = null;
      ClimaDto climaDtoAlias = null;

      var query = _session.QueryOver(() => climaAlias)
        .JoinAlias(() => climaAlias.Cidade, () => cidadeAlias)
        .JoinAlias(() => cidadeAlias.Estado, () => estadoAlias)
        .Where(() => cidadeAlias.Id == cidadeId);

      var lstClimas = (await query
        .OrderBy(x => x.Data).Asc
        .SelectList(l => l
          .Select(() => climaAlias.Id).WithAlias(() => climaDtoAlias.Id)
          .Select(() => climaAlias.TemperaturaMaxima).WithAlias(() => climaDtoAlias.TemperaturaMaximaDouble)
          .Select(() => climaAlias.TemperaturaMinima).WithAlias(() => climaDtoAlias.TemperaturaMinimaDouble)
          .Select(() => climaAlias.Temperatura).WithAlias(() => climaDtoAlias.TemperaturaDouble)
          .Select(() => climaAlias.Descricao).WithAlias(() => climaDtoAlias.Descricao)
          .Select(() => climaAlias.Data).WithAlias(() => climaDtoAlias.DataDateTime)
          .Select(() => climaAlias.TipoClima).WithAlias(() => climaDtoAlias.TipoClimaEnum)
          .Select(() => cidadeAlias.Id).WithAlias(() => climaDtoAlias.CidadeId)
          .Select(() => cidadeAlias.Nome).WithAlias(() => climaDtoAlias.CidadeNome)
          .Select(() => estadoAlias.Id).WithAlias(() => climaDtoAlias.EstadoId)
          .Select(() => estadoAlias.Sigla).WithAlias(() => climaDtoAlias.SiglaEnum)
        ).TransformUsing(Transformers.AliasToBean<ClimaDto>())
        .ListAsync<ClimaDto>()).ToList();

      return lstClimas;
    }
  }
}
