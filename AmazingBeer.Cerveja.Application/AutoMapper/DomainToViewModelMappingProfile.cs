using AmazingBeer.Cerveja.Application.AppModel.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingBeer.Cerveja.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.CervejaAggregate.Cerveja, CervejaDTO >();
        }
    }
}
