using GkMS_Test1.Printers.Application.Interfaces;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
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

        public IEnumerable<Printer> GetPrinters()
        {
            return _printerRepository.GetPrinters();
        }
    }
}
