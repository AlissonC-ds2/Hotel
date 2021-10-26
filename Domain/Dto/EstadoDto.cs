using Hotel.Domain.Enums;
using Hotel.Infra.CrossCutting.String_Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Dto
{
  public class EstadoDto
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public EstadoSiglaEnum SiglaEnum { get; set; }
    public string Sigla => SiglaEnum.ToDescription();

  }
}
