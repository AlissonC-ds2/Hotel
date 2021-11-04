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
		public double Temperatura { get; set; }
		public double TemperaturaMaxima { get; set; }
		public double TemperaturaMinima { get; set; }
		public string Descricao { get; set; }
		public string Umidade { get; set; }
		public double Velocidade { get; set; }
		public long EstadoId { get; set; }
		public long CidadeId { get; set; }
		public string CidadeNome { get; set; }
		public double PressaoAtm { get; set; }
		public ETipoClima TipoClimaEnum { get; set; }
		public string TipoClima => TipoClimaEnum.ToDescription();
		public EstadoSiglaEnum SiglaEnum { get; set; }
		public string Sigla => SiglaEnum.ToDescription();
	}
}
