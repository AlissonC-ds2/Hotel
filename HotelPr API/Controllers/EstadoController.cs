using AutoMapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Model;
using Hotel.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
	[Route("api/estado")]
	[ApiController]
	public class EstadoController : ControllerBase
	{
		private readonly BaseController _baseController;

		public EstadoController(BaseController baseController)
		{
			_baseController = baseController;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] EstadoModel model)
		=> await _baseController.Post<Estado, EstadoModel>(model);


		[HttpPut]
		public async Task<IActionResult> Put([FromBody] EstadoModel model)
		=> await _baseController.Put<Estado, EstadoModel>(model);


		[HttpDelete("id:int")]
		public async Task<IActionResult> Delete(int id)
		=> await _baseController.Delete<Estado>(id);

	}
}
