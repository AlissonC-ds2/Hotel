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
	[AutoMap(typeof(Clima), ReverseMap = true)]
	public class ClimaModel : BaseModel
	{
		public double Temperatura { get; set; }
		public double TemperaturaMaxima { get; set; }
		public double TemperaturaMinima { get; set; }
		public string Descricao { get; set; }
		public string Umidade { get; set; }
		public double Velocidade { get; set; }
		public long CidadeId { get; set; }
		public string CidadeNome { get; set; }
		public double PressaoAtm { get; set; }
		public ETipoClima TipoClima { get; set; }
	}
}
