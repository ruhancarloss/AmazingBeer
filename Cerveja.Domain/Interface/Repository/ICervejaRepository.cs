using AmazingBeer.Cerveja.Domain.CervejaAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Interface.Repository
{
    public interface ICervejaRepository
    {
        void Create(CervejaAggregate.Cerveja cerveja);
        CervejaAggregate.Cerveja Read(Guid id);
        IEnumerable<CervejaAggregate.Cerveja> ReadAll();
        void Update(CervejaAggregate.Cerveja product);
        void Delete(Guid id);
    }
}
