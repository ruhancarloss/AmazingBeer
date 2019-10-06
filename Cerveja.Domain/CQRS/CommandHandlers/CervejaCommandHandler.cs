using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.CommandHandlers
{
    public class CervejaCommandHandler
    {
        private readonly ICervejaService _cervejaService;

        public CervejaCommandHandler(ICervejaService cervejaService)
        {
            _cervejaService = cervejaService;
        }

        public void Handle(CreateCervejaCommand command)
        {
            _cervejaService.Create(command.Cerveja);
        }

        public void Handle(UpdateCervejaCommand command)
        {
            _cervejaService.Update(command.Cerveja);
        }

        public void Handle(DeleteCervejaCommand command)
        {
            _cervejaService.Delete(command.Cerveja.Id);
        }
    }
}