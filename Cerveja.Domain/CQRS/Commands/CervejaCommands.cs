using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS.Commands
{
    public abstract class CervejaCommands : QueueMessage
    {
        public CervejaAggregate.Cerveja cerveja { get; protected set; }
    }
}
