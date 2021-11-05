using Hotel.Domain.Enums;
using Hotel.Infra.CrossCutting.String_Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Dto
{
  public class ClimaDto
  {
		public long Id { get; set; }
		public DateTime DataDateTime { get; set; }
		public string Data => DataDateTime.ToString("dd/MM/yyyy");
		public double TemperaturaDouble { get; set; }
		public string Temperatura => TemperaturaDouble + " ºC";
		public double TemperaturaMaximaDouble { get; set; }
		public string TemperaturaMaxima => TemperaturaMaximaDouble + " ºC";
		public double TemperaturaMinimaDouble { get; set; }
		public string TemperaturaMinima => TemperaturaMinimaDouble + " ºC";
		public string Descricao { get; set; }
		public string Umidade { get; set; }
		public double VelocidadeDouble { get; set; }
		public string Velocidade => VelocidadeDouble + "km/h";
		public long EstadoId { get; set; }
		public long CidadeId { get; set; }
		public string CidadeNome { get; set; }
		public double PressaoAtmDouble { get; set; }
		public string PressaoAtm => PressaoAtmDouble + " Atm";
		public ETipoClima TipoClimaEnum { get; set; }
		public string TipoClima => TipoClimaEnum.ToDescription();
		public EstadoSiglaEnum SiglaEnum { get; set; }
		public string Sigla => SiglaEnum.ToDescription();
	}
}
