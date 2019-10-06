using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS.Commands
{
    public abstract class CreateCervejaCommand : CervejaCommands
    {
        public CreateCervejaCommand(CervejaAggregate.Cerveja cerveja)
        {
            this.QueueName = "create-cerveja-command-queue";
            this.cerveja = cerveja;
        }
    }
}
