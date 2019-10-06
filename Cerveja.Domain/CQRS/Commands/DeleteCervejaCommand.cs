using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.Commands
{
    public class DeleteCervejaCommand : CervejaCommands
    {
        public const string ConstQueueName = "delete-cerveja-command-queue";
        public override string QueueName { get => ConstQueueName; }

        public DeleteCervejaCommand(CervejaAggregate.Cerveja cerveja)
            : base(cerveja)
        {
        }
    }
}
