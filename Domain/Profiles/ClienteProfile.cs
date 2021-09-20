using AutoMapper;
using Hotel.Domain.Entities;
using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Profiles
{
  public class ClienteProfile : Profile
  {

    public ClienteProfile()
    {
      CreateMap<Cliente, ClienteModel>();
    }

  }
}
