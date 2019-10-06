using AmazingBeer.Cerveja.Domain.CervejaAggregate;
using AmazingBeer.Cerveja.Domain.Interface.Repository;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Services
{
    public class CervejaQueryService : ICervejaQueryService
    {
        private readonly ICervejaRepository _cervejaRepository;

        public CervejaQueryService(ICervejaRepository cervejaRepository)
        {
            _cervejaRepository = cervejaRepository;
        }

        public IEnumerable<CervejaAggregate.Cerveja> GetAllCervejas()
        {
            return _cervejaRepository.ReadAll();
        }

        public CervejaAggregate.Cerveja GetCerveja(Guid id)
        {
            return _cervejaRepository.Read(id);
        }
    }
}
