using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Interfaces
{
    public interface IPrinterRepository
    {
        IEnumerable<Printer> GetPrinters();        
        void Add(UserPrinter userPrinter);
    }
}
