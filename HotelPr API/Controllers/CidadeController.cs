using AutoMapper;
using Dapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Hotel.Infra.Data.ContextDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
  [Route("api/cidade")]
  [ApiController]
  public class CidadeController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly DapperContext _context;

    public CidadeController(IMapper mapper, IRepository repository, DapperContext context)
    {
      _mapper = mapper;
      _repository = repository;
      _context = context;
    }

    [HttpPost]
    public async Task Post([FromForm] CidadeModel model)
    {
      var cidade = _mapper.Map<Cidade>(model);

      var query = "INSERT INTO Cidade (Nome, EstadoId) VALUES (@Nome, @EstadoId)";

      var parameters = new DynamicParameters();

      parameters.Add("Nome", cidade.Nome, DbType.String);
      parameters.Add("EstadoId", cidade.Estado.Id, DbType.Int64); ;

      _repository.Post(query, parameters);
    }


    [HttpGet("GetAll")]
    public async Task<IReadOnlyList<Cidade>> GetAll()
    {
      var sql = "SELECT * FROM Cidade";

      using (var connection = _context.CreateConnection())
      {
        connection.Open();
        var result = await connection.QueryAsync<Cidade>(sql);
        return result.ToList();
      }

    }


    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
      string sql = "SELECT * FROM Cidade WHERE Id =" + id;

      using (var connection = _context.CreateConnection())
      {
        connection.Open();

        var cidade = connection.QueryFirstOrDefault<Cidade>(sql, id);

        return Ok(_mapper.Map<Cidade, CidadeModel>(cidade));
      }

    }


  }
}
