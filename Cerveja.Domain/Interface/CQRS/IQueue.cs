using Cerveja.Domain.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cerveja.Domain.Interface.CQRS
{
    public interface IQueue
    {
        Task EnqueueAsync(QueueMessage message);
        Task<string> DequeueAsync(string queueName);
    }
}
