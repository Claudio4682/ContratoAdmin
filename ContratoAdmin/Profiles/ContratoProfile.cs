using AutoMapper;
using ContratoAdmin.Dtos;
using ContratoAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Profiles
{
    public class ContratoProfile : Profile
    {
        public ContratoProfile()
        {
            CreateMap<Contrato, ContratoReadDto>();
            CreateMap<Contrato, ContratoCreateDto>().ReverseMap();
        }


    }
}
