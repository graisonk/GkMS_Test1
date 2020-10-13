using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Application.Interfaces
{
    public interface IPrinterService
    {
        IEnumerable<Printer> GetPrinters();
        PrinterSlabVM GetPrinter(int id);
        void AddPrinter(PrinterSlabVM printer);
        void ModPrinter(int id, PrinterSlabVM printer);
        void DelPrinter(int id);

        List<UserPrinter> GetUserPrinters(string userid);
        void UpdateRefRates(PrinterRates rates);
    }
}
