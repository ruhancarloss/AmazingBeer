using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.Interface.Service
{
    public interface ICervejaCommandService
    {
        void Create(CervejaAggregate.Cerveja catalogProduct);
        void Update(CervejaAggregate.Cerveja catalogProduct);
        void Delete(Guid id);
        void SaveChanges();
        //Task SaveChangesAsync();
    }
}
