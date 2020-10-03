using GkMS_Test1.Printers.Data.Context;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Data.Repository
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly PrinterDbContext _context;

        public PrinterRepository(PrinterDbContext context)
        {
            _context = context;
        }

        public async void Add(UserPrinter userPrinter)
        {
            _context.UserPrinters.Add(userPrinter);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Printer> GetPrinters()
        {
            return _context.Printers;
        }
    }
}
