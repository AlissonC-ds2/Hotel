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
    public virtual string Nome { get; set; }
    public virtual long EstadoId { get; set; }

  }
}
