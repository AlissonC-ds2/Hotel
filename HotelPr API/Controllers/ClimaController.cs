using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
  [Route("api/clima")]
  [ApiController]
  public class ClimaController : ControllerBase
  {
    private readonly BaseController _baseController;
    private readonly IClimaRepository _climaRepository;

    public ClimaController(BaseController baseController, IClimaRepository climaRepository)
    {
      _baseController = baseController;
      _climaRepository = climaRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ClimaModel model)
    => await _baseController.Post<Clima, ClimaModel>(model);


    [HttpPut]
    public async Task<IActionResult> Put([FromForm] ClimaModel model)
    => await _baseController.Put<Clima, ClimaModel>(model);


    [HttpDelete("id:int")]
    public async Task<IActionResult> Delete(int id)
    => await _baseController.Delete<Clima>(id);

    [HttpGet("{cidadeid:int}")]
    public async Task<IActionResult> GetAll(long cidadeId)
    => Ok(await _climaRepository.GetAllClimas(cidadeId));
  }
}
