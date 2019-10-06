using Cerveja.Domain.CQRS.Commands;
using Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS.CommandHandlers
{
    public class CervejaCommandHandler
    {
        private readonly ICervejaCommandService _cervejaCommandService;
        private readonly ICervejaQueryService _cervejaQueryService;

        public CervejaCommandHandler(ICervejaCommandService CervejaCommandService, ICervejaQueryService CervejaQueryService)
        {
            _cervejaCommandService = CervejaCommandService;
            _cervejaQueryService = CervejaQueryService;
        }

        public void Handle(CreateCervejaCommand command)
        {
            _cervejaCommandService.Create(command.cerveja);
            _cervejaCommandService.SaveChanges();
        }

        public void Handle(UpdateCervejaCommand command)
        {
            _cervejaCommandService.Update(command.cerveja);
            _cervejaCommandService.SaveChanges();
        }

        public void Handle(DeleteCervejaCommand command)
        {
            _cervejaCommandService.Delete(command.cerveja.Id);
            _cervejaCommandService.SaveChanges();
        }
    }
}