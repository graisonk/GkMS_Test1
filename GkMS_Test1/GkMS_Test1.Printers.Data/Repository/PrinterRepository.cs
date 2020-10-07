using GkMS_Test1.Printers.Data.Context;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Printer GetPrinter(int id)
        {
            return _context.Printers.Find(id);
        }

        public IEnumerable<Printer> GetPrinters()
        {
            return _context.Printers;
        }
        public void Add(UserPrinter userPrinter)
        {
            _context.UserPrinters.Add(userPrinter);
            _context.SaveChanges();
        }
        public void ModifyPrinter(int id, Printer printer)
        {
            if (id == printer.Id)
            {
                _context.Printers.Update(printer);
                _context.SaveChanges();
            }
        }

        public void DeletePrinter(int id)
        {
            Printer printer = _context.Printers.Find(id);
            if (printer != null)
            {
                _context.Printers.Remove(printer);
                _context.SaveChanges();
            }
        }

        public void AddPrinter(Printer printer)
        {
            _context.Printers.Add(printer);
            _context.SaveChanges();
        }

        public List<UserPrinter> GetUserPrinters(string userid)
        {
            List<UserPrinter> printers = new List<UserPrinter>();
            string[] asd = { "" };
            asd = userid.Split('=');
            if (asd[1] != "")
            {
                int tmpId = Convert.ToInt32(asd[1]);
                printers = _context.UserPrinters.Include(p => p.Printer).Where(p => p.UserId == tmpId).ToList();                
            }

            return printers;
        }
    }
}
