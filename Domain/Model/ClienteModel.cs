using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
  public class ClienteModel 
  {
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Nacionalidade { get; set; }
    public string Cidade { get; set; }
  }
}
