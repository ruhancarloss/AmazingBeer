using AmazingBeer.Cerveja.Domain.CervejaAggregate;
using AmazingBeer.Cerveja.Domain.Interface.Repository;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Services
{
    public class CervejaCommandService : ICervejaCommandService
    {
        private readonly ICervejaRepository _cervejaRepository;

        public CervejaCommandService(ICervejaRepository cervejaRepository)
        {
            _cervejaRepository = cervejaRepository;
        }

        public void Create(CervejaAggregate.Cerveja cerveja)
        {
            _cervejaRepository.Create(cerveja);
        }

        public void Delete(Guid id)
        {
            _cervejaRepository.Delete(id);
        }

        public void Update(CervejaAggregate.Cerveja cerveja)
        {
            _cervejaRepository.Update(cerveja);
        }
    }
}
