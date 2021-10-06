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
  [Route("api/cliente")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly DapperContext _context;

    public ClienteController(IMapper mapper, IRepository repository, DapperContext context)
    {
      _mapper = mapper;
      _repository = repository;
      _context = context;
    }

    [HttpPost]
    public async Task Post([FromForm]ClienteModel model)
    {
      var cliente = _mapper.Map<Cliente>(model);

      var query = "INSERT INTO Cliente (Nome, Endereco, Nacionalidade, Cidade) VALUES (@Nome, @Endereco, @Nacionalidade, @Cidade)";

      var parameters = new DynamicParameters();

      parameters.Add("Nome", cliente.Nome, DbType.String);
      parameters.Add("Endereco", cliente.Endereco, DbType.String);
      parameters.Add("Nacionalidade", cliente.Nacionalidade, DbType.String);
      parameters.Add("Cidade", cliente.Cidade, DbType.String);

      _repository.Post(query, parameters);
    }


    [HttpGet]
    public async Task<IReadOnlyList<Cliente>> GetAll() 
    {
      var sql = "SELECT * FROM Cliente";

      using (var connection = _context.CreateConnection())
      {
        connection.Open();
        var result = await connection.QueryAsync<Cliente>(sql);
        return result.ToList();
      }

    }
  }
}
