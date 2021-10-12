using AutoMapper;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
  [AutoMap(typeof(Cidade), ReverseMap = true)]
  public class CidadeModel : BaseModel
  {
    public string Nome { get; set; }
    public long EstadoId { get; set; }

  }
}
