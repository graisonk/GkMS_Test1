using GkMS_Test1.Invoice.Application.Interfaces;
using GkMS_Test1.Invoice.Domain.Interfaces;
using GkMS_Test1.Invoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Invoice.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public void AddInvoice(Invoices Inv)
        {
            _invoiceRepository.AddInvoice(Inv);
        }

        public void DelInvoice(int id)
        {
            _invoiceRepository.DeleteInvoice(id);
        }

        public Invoices GetInvoice(int id)
        {
            return _invoiceRepository.GetInvoice(id);
        }

        public IEnumerable<Invoices> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }

        public void ModInvoice(int id, Invoices Inv)
        {
            _invoiceRepository.ModifyInvoice(id, Inv);
        }
    }
}
