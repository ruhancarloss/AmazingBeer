using AmazingBeer.Cerveja.Application.AppModel.DTO;
using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Interface.CQRS;
using AmazingBeer.Cerveja.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AmazingBeer.Cerveja.Application
{
    public interface IApiAppService
    {
        IEnumerable<CervejaDTO> GetAllCervejas();
        CervejaDTO ReadCerveja(Guid id);
        void UpdateCerveja(CervejaDTO CervejaDTO);
        void DeleteCerveja(CervejaDTO CervejaDTO);
        void AddCerveja(CervejaDTO CervejaDTO);
    }
}
