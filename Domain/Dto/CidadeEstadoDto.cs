using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Dto
{
  public class CidadeEstadoDto
  {
    public int Id { get; set; }
    public int EstadoId { get; set; }
    public string Nome { get; set; }
    public string EstadoNome { get; set; }
  }
}
