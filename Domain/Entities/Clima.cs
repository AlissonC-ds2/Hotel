using Hotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
	public class Clima : BaseEntity
	{
		public virtual double Temperatura { get; set; }
		public virtual double TemperaturaMaxima { get; set; }
		public virtual double TemperaturaMinima { get; set; }
		public virtual string Descricao { get; set; }
		public virtual string Umidade { get; set; }
		public virtual double Velocidade { get; set; }
		public virtual Cidade Cidade { get; set; }
		public virtual double PressaoAtm { get; set; }
		public virtual ETipoClima TipoClima { get; set; }
	}
}
