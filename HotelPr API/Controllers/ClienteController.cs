using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {

    //public async Task CreateCompany(CompanyForCreationDto model)
    //{
    //  var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
    //  var parameters = new DynamicParameters();
    //  parameters.Add("Name", model.Name, DbType.String);
    //  parameters.Add("Address", model.Address, DbType.String);
    //  parameters.Add("Country", model.Country, DbType.String);
    //  using (var connection = _context.CreateConnection())
    //  {
    //    await connection.ExecuteAsync(query, parameters);
    //  }
    //}

  }
}
