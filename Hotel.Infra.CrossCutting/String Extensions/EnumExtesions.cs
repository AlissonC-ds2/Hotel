using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infra.CrossCutting.String_Extensions
{
  public static class EnumExtesions
  {

    public static string ToDescription(this Enum enumValue)
    {
      var descriptionAttribute = enumValue.GetType()
          .GetField(enumValue.ToString())
          .GetCustomAttributes(false)
          .SingleOrDefault(attr => attr.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute;

      // return description
      return descriptionAttribute?.Description ?? "";
    }

  }
}
