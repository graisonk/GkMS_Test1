using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.Commands
{
    public class CreatePrinterCommand : PrinterCommand
    {
        public CreatePrinterCommand(int userid, int printerid, bool isAssigned)
        {
            UserId = userid;
            PrinterId = printerid;
            IsAssigned = isAssigned;
        }
    }
}
