using AutoMapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
  [AutoMap(typeof(Estado), ReverseMap = true)]
  public class EstadoModel : BaseModel
  {
    public string Nome { get; set; }
    public EstadoSiglaEnum Sigla { get; set; }
  }
}
