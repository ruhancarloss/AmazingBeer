using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AmazingBeer.Cerveja.Domain;
using AmazingBeer.Cerveja.Infrastructure.Properties;

namespace AmazingBeer.Cerveja.Infrastructure.DataAccess.Contexts
{
    public class CervejaContext : DbContext
    {
        public DbSet<AmazingBeer.Cerveja.Domain.CervejaAggregate.Cerveja> Cerveja { get; set; }

        public CervejaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Resources.DbConnectionString);
        }
    }
}
