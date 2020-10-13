using GkMS_Test1.Invoice.Domain.Interfaces;
using GkMS_Test1.Invoice.Data.Context;
using GkMS_Test1.Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace GkMS_Test1.Invoice.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext _context;

        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }        

        public Invoices GetInvoice(int id)
        {
            return _context.Invoices.Include(i => i.Ref_User).Include(i => i.Ref_Printer).Single(i => i.Id == id);
        }

        public IEnumerable<Invoices> GetInvoices()
        {
            return _context.Invoices.Include(i => i.Ref_User).Include(i => i.Ref_Printer);
        }
        public void ModifyInvoice(int id, Invoices Inv)
        {
            if (id == Inv.Id)
            {
                _context.Invoices.Update(Inv);
                _context.SaveChanges();
            }
        }

        public void DeleteInvoice(int id)
        {
            Invoices Inv = _context.Invoices.Find(id);
            if (Inv != null)
            {
                _context.Invoices.Remove(Inv);
                _context.SaveChanges();
            }
        }

        public void AddInvoice(Invoices Inv)
        {
            _context.Invoices.Add(Inv);
            _context.SaveChanges();
        }

        public List<Ref_User> GetUsers(string Prefix)
        {
            return _context.Users.Where(c => c.Name.Contains(Prefix)).ToList();                        
        }

        public List<Ref_PrinterRates> PrinterRates(int userId, int ptrId)
        {
            var slabRates = _context.PrinterRates.Where(p => p.PrinterId == ptrId && p.UserId == userId);
            List<Ref_PrinterRates> rateList = slabRates.ToList();

            if (rateList.Count == 0)
            {
                slabRates = _context.PrinterRates.Where(p => p.PrinterId == ptrId && p.UserId == null);
                rateList = slabRates.ToList();
            }
            return rateList;
        }

        public void ModifyRates(Ref_PrinterRates rates)
        {
            Ref_PrinterRates printerRates = _context.PrinterRates.Single(i => i.RefDbId == rates.Id);
            if (printerRates!=null)
            {
                printerRates.ValFrom = rates.ValFrom;
                printerRates.ValTo = rates.ValTo;
                printerRates.Rate = rates.Rate;

                _context.PrinterRates.Update(printerRates);
                _context.SaveChanges();
            }
        }
    }
}
