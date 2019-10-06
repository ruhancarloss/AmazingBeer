using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS.Commands
{
    public abstract class DeleteCervejaCommand : CervejaCommands
    {
        public DeleteCervejaCommand(CervejaAggregate.Cerveja cerveja)
        {
            this.QueueName = "delete-cerveja-command-queue";
            this.cerveja = cerveja;
        }
    }
}
