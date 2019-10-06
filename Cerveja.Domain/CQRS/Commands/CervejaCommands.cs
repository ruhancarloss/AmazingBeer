using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.Commands
{
    public abstract class CervejaCommands : Command
    {
        public CervejaAggregate.Cerveja Cerveja { get; set; }

        protected CervejaCommands(CervejaAggregate.Cerveja cerveja)
        {
            Cerveja = cerveja;
        }
    }
}
