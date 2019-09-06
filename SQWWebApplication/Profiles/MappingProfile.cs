using AutoMapper;
using SQWWebApplication.Models;
using SQWWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Player, PlayerVm>().ReverseMap();
    }
  }
}
