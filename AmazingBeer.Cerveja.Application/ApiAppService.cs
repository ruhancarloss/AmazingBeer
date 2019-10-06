using AmazingBeer.Cerveja.Application.AppModel.DTO;
using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Interface.CQRS;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using AmazingBeer.Cerveja.Domain.Services;
using AmazingBeer.Cerveja.Infrastructure.CQRS;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AmazingBeer.Cerveja.Application
{
    public class ApiAppService : IApiAppService
    {
        private readonly IQueue _queue;
        private readonly IMapper _mapper;
        private readonly ICervejaService _cervejaService;

        public ApiAppService(IMapper mapper, ICervejaService cervejaService)
        {
            _queue = new RabbitMQueue();
            _mapper = mapper;
            _cervejaService = cervejaService;
        }

        //====== COMMANDS ======
        public void AddCerveja(CervejaDTO CervejaDTO)
        {
            var command = new CreateCervejaCommand(_mapper.Map<Domain.CervejaAggregate.Cerveja>(CervejaDTO));
            _queue.Enqueue(command);
        }

        public void UpdateCerveja(CervejaDTO CervejaDTO)
        {
            var command = new UpdateCervejaCommand(_mapper.Map<Domain.CervejaAggregate.Cerveja>(CervejaDTO));
            _queue.Enqueue(command);
        }

        public void DeleteCerveja(CervejaDTO CervejaDTO)
        {
            var command = new DeleteCervejaCommand(_mapper.Map<Domain.CervejaAggregate.Cerveja>(CervejaDTO));
            _queue.Enqueue(command);
        }

        public CervejaDTO ReadCerveja(Guid id)
        {
            var Cerveja = _cervejaService.GetCerveja(id);
            var CervejaDTO = _mapper.Map<CervejaDTO>(Cerveja);
            return CervejaDTO;
        }

        public IEnumerable<CervejaDTO> GetAllCervejas()
        {
            var Cervejas = _cervejaService.GetAllCervejas();
            return _mapper.Map<IEnumerable<CervejaDTO>>(Cervejas);
        }
        //=====================
    }
}
