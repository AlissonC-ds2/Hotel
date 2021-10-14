using Hotel.Domain.Enums;
using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
  public class Estado : BaseEntity
  {
    public virtual string Nome { get; set; }
    public virtual EstadoSiglaEnum Sigla { get; set; }
  }
}
