using GkMS_Test1.Printers.Application.Interfaces;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Application.Services
{
    public class PrinterService : IPrinterService
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterService(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }        

        public PrinterSlabVM GetPrinter(int id)
        {
            return _printerRepository.GetPrinter(id);
        }

        public IEnumerable<Printer> GetPrinters()
        {
            return _printerRepository.GetPrinters();
        }

        public void ModPrinter(int id, PrinterSlabVM printer)
        {
            _printerRepository.ModifyPrinter(id, printer);
        }
        public void DelPrinter(int id)
        {
            _printerRepository.DeletePrinter(id);
        }

        public void AddPrinter(PrinterSlabVM printer)
        {
            _printerRepository.AddPrinter(printer);
        }

        public List<UserPrinter> GetUserPrinters(string userid)
        {
            return _printerRepository.GetUserPrinters(userid);
        }
    }
}
