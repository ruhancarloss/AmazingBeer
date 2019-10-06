using AmazingBeer.Cerveja.Application.AppModel.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingBeer.Cerveja.Service.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CervejaDTO, Domain.CervejaAggregate.Cerveja>();
        }
    }
}
