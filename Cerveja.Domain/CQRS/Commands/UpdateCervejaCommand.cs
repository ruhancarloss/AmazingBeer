using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Domain.CQRS.Commands
{
    public class UpdateCervejaCommand : CervejaCommands
    {
        public const string ConstQueueName = "update-cerveja-command-queue";
        public override string QueueName { get => ConstQueueName; }

        public UpdateCervejaCommand(CervejaAggregate.Cerveja cerveja)
            : base(cerveja)
        {
        }
    }
}
