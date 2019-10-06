using AmazingBeer.Cerveja.Domain.CervejaAggregate;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Services
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

        public CervejaAggregate.Cerveja GetCerveja(Guid id)
        {
            return _cervejaQueryService.Get(id);
        }
    }
}
