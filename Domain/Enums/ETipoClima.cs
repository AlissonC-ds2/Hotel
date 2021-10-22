using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Enums
{
	public enum ETipoClima
	{
    [Description("Equatorial")]
    Equatorial = 0,
    [Description("Tropical")]
    Tropical = 1,
    [Description("Semiárido")]
    Semiárido = 2,
    [Description("Tropical de Altitude")]
    Tropical_de_altitude = 3,
    [Description("Tropical Atlântico")]
    Tropical_Atlantico = 4,
    [Description("Subtropical")]
    Subtropical = 5
  }
}
