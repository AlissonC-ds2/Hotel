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
  [Route("api/cidade")]
  [ApiController]
  public class CidadeController : ControllerBase
  {
    private readonly BaseController _baseController;
    private readonly ICidadeRepository _cidadeRepository;

    public CidadeController(BaseController baseController, ICidadeRepository cidadeRepository)
    {
      _baseController = baseController;
      _cidadeRepository = cidadeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CidadeModel model)
    => await _baseController.Post<Cidade, CidadeModel>(model);


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CidadeModel model)
    => await _baseController.Put<Cidade, CidadeModel>(model);


    [HttpDelete("id:int")]
    public async Task<IActionResult> Delete(int id)
    => await _baseController.Delete<Cidade>(id);

    [HttpGet("getallcidadesestado")]
    public async Task<IActionResult> GetAllCidades()
    => Ok(await _cidadeRepository.GetAllCidadades());

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllCidadesEstado(long unidadeId)
    => Ok(await _cidadeRepository.GetAllCidadadesEstado(unidadeId));


  }
}
