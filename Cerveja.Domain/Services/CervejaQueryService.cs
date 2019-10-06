using Cerveja.Domain.CervejaAggregate;
using Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.Services
{
    public class CervejaQueryService
    {
        private readonly ICervejaQueryService _cervejaQueryService;

        public CervejaQueryService(ICervejaQueryService cervejaQueryService)
        {
            _cervejaQueryService = cervejaQueryService;
        }

        public IEnumerable<CervejaAggregate.Cerveja> GetAllCervejas()
        {
            return _cervejaQueryService.GetAll();
        }
    }
}
