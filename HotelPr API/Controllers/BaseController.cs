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
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController : ControllerBase
  {
    private readonly IRepository _session;

    public BaseController(IRepository session)
    {
      _session = session;
    }


    [HttpPost]
    public async Task Post<T>(T model) where T : BaseModel
    {
      //Fazer a conversão do model para entidade e depois salvar a entidade !!!!!
      try
      {
        _session.BeginTransaction();

        await _session.Save(model);
        await _session.Commit();
      }
      catch
      {
        await _session.Rollback();
      }
      finally
      {
        _session.CloseTransaction();
      }
    }

  }
}
