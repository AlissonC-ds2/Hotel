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
		public double Temperatura { get; set; }
		public double TemperaturaMaxima { get; set; }
		public double TemperaturaMinima { get; set; }
		public string Descricao { get; set; }
		public string Umidade { get; set; }
		public double Velocidade { get; set; }
		public Cidade Cidade { get; set; }
		public double PressaoAtm { get; set; }
		public ETipoClima TipoClima { get; set; }
	}
}
