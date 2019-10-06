using Cerveja.Domain.CervejaAggregate;
using Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.Services
{
    public class CervejaCommandService
    {
        private readonly ICervejaCommandService _cervejaCommandService;

        public CervejaCommandService(ICervejaCommandService cervejaCommandService)
        {
            _cervejaCommandService = cervejaCommandService;
        }

        public void AddCerveja(CervejaAggregate.Cerveja cerveja)
        {
            _cervejaCommandService.Create(cerveja);
            _cervejaCommandService.SaveChanges();
        }
    }
}
