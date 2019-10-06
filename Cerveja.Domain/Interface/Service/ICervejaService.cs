using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Interface.Service
{
    public interface ICervejaService
    {
        IEnumerable<CervejaAggregate.Cerveja> GetAllCervejas();
        CervejaAggregate.Cerveja GetCerveja(Guid id);
        void Create(CervejaAggregate.Cerveja catalogProduct);
        void Update(CervejaAggregate.Cerveja catalogProduct);
        void Delete(Guid id);
    }
}
