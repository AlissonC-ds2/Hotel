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
	[Route("api/estado")]
	[ApiController]
	public class EstadoController : ControllerBase
	{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly DapperContext _context;

    public EstadoController(IMapper mapper, IRepository repository, DapperContext context)
    {
      _mapper = mapper;
      _repository = repository;
      _context = context;
    }

    [HttpPost]
    public async Task Post([FromForm] EstadoModel model)
    {
      var estado = _mapper.Map<Estado>(model);

      var query = "INSERT INTO Estado (Nome, Sigla) VALUES (@Nome, @Sigla)";

      var parameters = new DynamicParameters();

      parameters.Add("Nome", estado.Nome, DbType.String);
      parameters.Add("Sigla", estado.Sigla, DbType.Int64);

      _repository.Post(query, parameters);
    }


    [HttpGet("GetAll")]
    public async Task<IReadOnlyList<Estado>> GetAll()
    {
      var sql = "SELECT * FROM Estado";

      using (var connection = _context.CreateConnection())
      {
        connection.Open();
        var result = await connection.QueryAsync<Estado>(sql);
        return result.ToList();
      }

    }


    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
      string sql = "SELECT * FROM Estado WHERE Id =" + id;

      using (var connection = _context.CreateConnection())
      {
        connection.Open();

        var estado = connection.QueryFirstOrDefault<Estado>(sql, id);

        return Ok(_mapper.Map<Estado, EstadoModel>(estado));
      }

    }



  }
}
