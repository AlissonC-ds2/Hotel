using Hotel.Domain.Dto;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.Data.Repositories
{
  public class CidadeRepository : ICidadeRepository
  {
    private readonly ISession _session;

    public CidadeRepository(ISession session)
    {
      _session = session;
    }

    public async Task<List<CidadeEstadoDto>> GetAllCidadadesEstado()
    {
      Estado estadoAlias = null;
      Cidade cidadeAlias = null;
      CidadeEstadoDto cidadeEstadoDtoAlias = null;

      var query = _session.QueryOver(() => cidadeAlias)
        .JoinAlias(() => cidadeAlias.Estado, () => estadoAlias);


      var lstCidades = (await query
        .SelectList(l => l
          .Select(()=> cidadeAlias.Id).WithAlias(() => cidadeEstadoDtoAlias.Id)
          .Select(()=> cidadeAlias.Nome).WithAlias(() => cidadeEstadoDtoAlias.Nome)
          .Select(()=> estadoAlias.Id).WithAlias(() => cidadeEstadoDtoAlias.EstadoId)
          .Select(()=> estadoAlias.Nome).WithAlias(() => cidadeEstadoDtoAlias.EstadoNome)
        ).TransformUsing(Transformers.AliasToBean<CidadeEstadoDto>()).ListAsync<CidadeEstadoDto>()).ToList();

      return lstCidades;
    }
  }
}
