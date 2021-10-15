using Hotel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
  public interface ICidadeRepository
  {
    public Task<List<CidadeEstadoDto>> GetAllCidadades();
    public Task<List<CidadeEstadoDto>> GetAllCidadadesEstado(long estadoId);
  }
}
