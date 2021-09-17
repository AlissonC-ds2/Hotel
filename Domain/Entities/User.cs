using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain
{
  public class User : BaseEntity
  {
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }



    public override bool Equals(object obj)
    {
      return obj is User user &&
             Id == user.Id;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Id);
    }

  }
}
