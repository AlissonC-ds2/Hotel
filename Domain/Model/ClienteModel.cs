using AutoMapper;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
  [AutoMap(typeof(Cliente), ReverseMap = true)]
  public class ClienteModel : BaseModel
  {
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string DataNasc { get; set; }
    public string Nacionalidade { get; set; }
    public string Cidade { get; set; }
  }
}
