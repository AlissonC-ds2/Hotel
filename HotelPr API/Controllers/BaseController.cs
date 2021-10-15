using AutoMapper;
using Hotel.Domain;
using Hotel.Domain.Model;
using Hotel.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPr_API.Controllers
{
  [ApiController]
	public class BaseController //: ControllerBase
  {
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISession _session;

		public BaseController(IRepository repository, IMapper mapper, ISession session)
		{
			_repository = repository;
			_mapper = mapper;
			_session = session;
		}

		public async Task<IActionResult> Post<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel
    {
      var entity = _mapper.Map<T>(model);
      try
      {
        _repository.BeginTransaction();

        await _repository.Save(entity);
        await _repository.Commit();
      }
      catch
      {
        await _repository.Rollback();
      }
      finally
      {
        _repository.CloseTransaction();
      }

      
      _mapper.Map(entity, model);

      return new OkObjectResult(model);
    }



    public async Task<IActionResult> Put<T, TDestination>(TDestination model) where T : BaseEntity where TDestination : BaseModel
    {

      var entidade = await _session.GetAsync<T>(model.Id);
      _mapper.Map(model, entidade);

      try
      {
        _repository.BeginTransaction();

        await _repository.Save(entidade);
        await _repository.Commit();
      }
      catch
      {
        await _repository.Rollback();
      }
      finally
      {
        _repository.CloseTransaction();
      }


      _mapper.Map(entidade, model);

      return new OkObjectResult(model);
    }


    public async Task<IActionResult> Delete<T>(int id) where T : BaseEntity
    {
      var entidade = await _session.GetAsync<T>(id);

      try
      {
        _repository.BeginTransaction();

        await _repository.Delete(entidade);
        await _repository.Commit();
      }
      catch
      {
        await _repository.Rollback();
      }
      finally
      {
        _repository.CloseTransaction();
      }

      return null;
    }




  }
}
