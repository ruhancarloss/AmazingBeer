using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingBeer.Cerveja.Infrastructure.DataAccess.Contexts;
using AmazingBeer.Cerveja.Domain.Interface.Repository;

namespace AmazingBeer.Cerveja.Infrastructure.DataAccess.Repositories.EFCore
{
    public class CervejaRepository : ICervejaRepository
    {
        private readonly CervejaContext _context;

        public CervejaRepository()
        {
            _context = new CervejaContext();
        }

        public void Create(Domain.CervejaAggregate.Cerveja cerveja)
        {
            _context.Cerveja.Add(cerveja);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Cerveja.Remove(Read(id));
            _context.SaveChanges();
        }

        public Domain.CervejaAggregate.Cerveja Read(Guid id)
        {
            return _context.Cerveja.Find(id);
        }

        public IEnumerable<Domain.CervejaAggregate.Cerveja> ReadAll()
        {
            return _context.Cerveja;
        }

        public void Update(Domain.CervejaAggregate.Cerveja cerveja)
        {
            Delete(cerveja.Id);
            Create(cerveja);
            _context.SaveChanges();
        }
    }
}
