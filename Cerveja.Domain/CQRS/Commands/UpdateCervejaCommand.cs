using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.CQRS.Commands
{
    public abstract class UpdateCervejaCommand : CervejaCommands
    {
        public UpdateCervejaCommand(CervejaAggregate.Cerveja cerveja)
        {
            this.QueueName = "update-cerveja-command-queue";
            this.cerveja = cerveja;
        }
    }
}
