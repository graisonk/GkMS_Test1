using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Interfaces
{
    public interface IPrinterRepository
    {
        void Add(UserPrinter userPrinter);
        void UpdateRefUser(Ref_User ref_User);
        IEnumerable<Printer> GetPrinters();
        PrinterSlabVM GetPrinter(int id);        
        void AddPrinter(PrinterSlabVM printer);
        void ModifyPrinter(int id, PrinterSlabVM printer);
        void DeletePrinter(int id);
        List<UserPrinter> GetUserPrinters(string userid);
    }
}
