using AutoMapper;
using Dapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public ClienteController(IMapper mapper, IRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }


    [HttpPost]
    public async Task Post(ClienteModel model)
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
  }
}
