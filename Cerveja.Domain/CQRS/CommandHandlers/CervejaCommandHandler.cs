using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.CommandHandlers
{
    public class CervejaCommandHandler
    {
        private readonly ICervejaCommandService _cervejaCommandService;

        public CervejaCommandHandler(ICervejaCommandService cervejaService)
        {
            _cervejaCommandService = cervejaService;
        }

        public void Handle(CreateCervejaCommand command)
        {
            _cervejaCommandService.Create(command.Cerveja);
        }

        public void Handle(UpdateCervejaCommand command)
        {
            _cervejaCommandService.Update(command.Cerveja);
        }

        public void Handle(DeleteCervejaCommand command)
        {
            _cervejaCommandService.Delete(command.Cerveja.Id);
        }
    }
}