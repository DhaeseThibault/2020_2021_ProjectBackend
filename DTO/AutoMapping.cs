using System;
using AutoMapper;
using ProjectBackend.Models;

namespace ProjectBackend.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Brewer, BrewerDTO>();
            CreateMap<BeerDTO,Beer>();
            CreateMap<UserDTO,User>();
        }
    }
}
