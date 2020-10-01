using GkMS_Test1.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.Commands
{
    public abstract class PrinterCommand : Command
    {
        public int UserId { get; protected set; }
        public int PrinterId { get; protected set; }
        public bool IsAssigned { get; protected set; }
    }
}
