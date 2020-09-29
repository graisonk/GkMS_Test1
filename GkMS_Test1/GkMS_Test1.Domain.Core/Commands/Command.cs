using GkMS_Test1.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
