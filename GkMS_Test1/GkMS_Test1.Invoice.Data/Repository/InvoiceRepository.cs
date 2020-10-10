using GkMS_Test1.Invoice.Domain.Interfaces;
using GkMS_Test1.Invoice.Data.Context;
using GkMS_Test1.Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _context.Invoices.Find(id);
        }

        public IEnumerable<Invoices> GetInvoices()
        {
            return _context.Invoices;
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
    }
}
