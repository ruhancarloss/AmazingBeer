using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.Commands
{
    public class CreateCervejaCommand : CervejaCommands
    {
        public const string ConstQueueName = "create-cerveja-command-queue";
        public override string QueueName { get => ConstQueueName; }

        public CreateCervejaCommand(CervejaAggregate.Cerveja cerveja)
            : base(cerveja)
        {
        }
    }
}
