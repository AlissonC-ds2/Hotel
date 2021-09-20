using AutoMapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPrMVC.Controllers
{
  public class ClienteController : Controller
  {

    private readonly IMapper _mapper;

    public ClienteController(IMapper mapper)
    {
      _mapper = mapper;
    }

    public IActionResult Index()
    {
      var cliente = GetCliente();

      var clienteModel = _mapper.Map<ClienteModel>(cliente);

      return View(clienteModel);
    }






    public static Cliente GetCliente ()
    {
      return new Cliente
      {
        Nome = "Alisson",
        Endereco = "Rua Amélias",
        Cidade = "Pato Branco",
        Nacionalidade = "Brasileiro"
      };
    }

  }
}
