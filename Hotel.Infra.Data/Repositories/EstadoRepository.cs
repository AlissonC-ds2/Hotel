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
  public class EstadoRepository : IEstadoRepository
  {
    private readonly ISession _session;


    public EstadoRepository(ISession session) 
    {
      _session = session;
    }

    public async Task<List<EstadoDto>> GetAllEstados()
    {
      EstadoDto estadoDtoAlias = null;
      Estado estadoAlias = null;


      var query = _session.QueryOver(() => estadoAlias);



      var lstEstado = (await query
        .SelectList(l => l
          .Select(() => estadoAlias.Id).WithAlias(() => estadoDtoAlias.Id)
          .Select(() => estadoAlias.Nome).WithAlias(() => estadoDtoAlias.Nome)
        ).TransformUsing(Transformers.AliasToBean<EstadoDto>()).ListAsync<EstadoDto>()).ToList();


      return lstEstado;
    }
  }
}
