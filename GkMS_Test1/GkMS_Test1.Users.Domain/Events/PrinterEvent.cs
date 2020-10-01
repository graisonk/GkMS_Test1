using GkMS_Test1.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GkMS_Test1.Users.Domain.Events
{
    public class PrinterEvent : Event
    {
        public int UserId { get; private set; }
        public int PrinterId { get; private set; }
        public bool IsAssigned { get; private set; }
        public PrinterEvent(int userid, int printerid, bool isAssigned)
        {
            UserId = userid;
            PrinterId = printerid;
            IsAssigned = isAssigned;
        }
    }
}
