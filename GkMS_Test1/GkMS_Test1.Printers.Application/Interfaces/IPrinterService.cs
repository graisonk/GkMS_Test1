using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Application.Interfaces
{
    public interface IPrinterService
    {
        IEnumerable<Printer> GetPrinters();
        Printer GetPrinter(int id);

        void ModPrinter(int id, Printer printer);
        void DelPrinter(int id);
    }
}
