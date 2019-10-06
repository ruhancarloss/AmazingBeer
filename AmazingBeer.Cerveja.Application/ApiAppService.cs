using AmazingBeer.Cerveja.Application.AppModel.DTO;
using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Interface.CQRS;
using AmazingBeer.Cerveja.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AmazingBeer.Cerveja.Application
{
    public class ApiAppService
    {
        private readonly IQueue _queue;
        private readonly IMapper _mapper;
        private readonly CervejaQueryService _cervejaQueryService;

        public ApiAppService(IQueue queue, IMapper mapper, CervejaQueryService cervejaQueryService)
        {
            _queue = queue;
            _mapper = mapper;
            _cervejaQueryService = cervejaQueryService;
        }

        //====== COMMANDS ======
        public void AddCerveja(CervejaDTO CervejaDTO)
        {
            var command = _mapper.Map<CreateCervejaCommand>(CervejaDTO);
            _queue.Enqueue(command);
        }

        public void UpdateCerveja(CervejaDTO CervejaDTO)
        {
            var command = _mapper.Map<UpdateCervejaCommand>(CervejaDTO);
            _queue.Enqueue(command);
        }

        public void DeleteCerveja(CervejaDTO CervejaDTO)
        {
            var command = _mapper.Map<DeleteCervejaCommand>(CervejaDTO);
            _queue.Enqueue(command);
        }
        //======================


        //====== QUERIES ======
        public CervejaDTO ReadCerveja(Guid id)
        {
            var Cerveja = _cervejaQueryService.GetCerveja(id);
            var CervejaDTO = _mapper.Map<CervejaDTO>(Cerveja);
            return CervejaDTO;
        }

        public IEnumerable<CervejaDTO> GetAllCervejas()
        {
            var Cervejas = _cervejaQueryService.GetAllCervejas();
            return _mapper.Map<IEnumerable<CervejaDTO>>(Cervejas);
        }
        //=====================
    }
}
