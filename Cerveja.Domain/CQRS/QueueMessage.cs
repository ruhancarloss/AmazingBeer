using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS
{
    public abstract class QueueMessage : Message
    {
        public abstract string QueueName { get; protected set; }
    }
}
