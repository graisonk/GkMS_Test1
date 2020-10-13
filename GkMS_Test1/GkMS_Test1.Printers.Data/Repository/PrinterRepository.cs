using GkMS_Test1.Printers.Data.Context;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
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
        public void Add(UserPrinter userPrinter)
        {
            _context.UserPrinters.Add(userPrinter);
            _context.SaveChanges();
        }
        public void UpdateRefUser(Ref_User ref_User)
        {
            Ref_User user = _context.Ref_Users.Where(i => i.RefDbId == ref_User.Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = ref_User.Name;
                _context.Ref_Users.Update(user);
                _context.SaveChanges();
            }
        }

        public PrinterSlabVM GetPrinter(int id)
        {
            PrinterSlabVM model = new PrinterSlabVM()
            {
                Printer = _context.Printers.Find(id),
                PrinterRates = _context.PrinterRates.Where(p => p.PrinterId == id).ToList()
            };
            return model;
        }

        public IEnumerable<Printer> GetPrinters()
        {
            return _context.Printers;
        }
        public void ModifyPrinter(int id, PrinterSlabVM printer)
        {
            if (id == printer.Printer.Id)
            {
                _context.Printers.Update(printer.Printer);

                int max = 0;
                if (printer.PrinterRates != null)
                {
                    max = printer.PrinterRates.Count;                    
                    for (int i = 0; i < max; i++)
                    {
                        if (printer.PrinterRates[i].Id == 0)
                        {                            
                            printer.PrinterRates[i].PrinterId = printer.Printer.Id;
                            _context.PrinterRates.Add(printer.PrinterRates[i]);
                        }
                        else
                        {
                            _context.PrinterRates.Update(printer.PrinterRates[i]);
                        }
                    }
                }
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

        public void AddPrinter(PrinterSlabVM printer)
        {
            _context.Printers.Add(printer.Printer);
            _context.SaveChanges();

            var count = 0;
            if (printer.PrinterRates != null)
                count = printer.PrinterRates.Count;

            for (int i = 0; i < count; i++)
            {
                printer.PrinterRates[i].PrinterId = printer.Printer.Id; 
                _context.PrinterRates.Add(printer.PrinterRates[i]);
            }

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
                tmpId = _context.Ref_Users.Single(i => i.RefDbId == tmpId).Id;
                printers = _context.UserPrinters.Include(p => p.Printer).Where(p => p.UserId == tmpId).ToList();
            }

            return printers;
        }
    }
}
