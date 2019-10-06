using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.Interface.Service
{
    public interface ICervejaQueryService
    {
        IEnumerable<CervejaAggregate.Cerveja> GetAllCervejas();
        CervejaAggregate.Cerveja GetCerveja(Guid id);
    }
}
