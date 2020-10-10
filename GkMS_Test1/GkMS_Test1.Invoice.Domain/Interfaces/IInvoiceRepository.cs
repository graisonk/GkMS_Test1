using GkMS_Test1.Invoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Invoice.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoices> GetInvoices();
        Invoices GetInvoice(int id);
        void AddInvoice(Invoices Inv);
        void ModifyInvoice(int id, Invoices Inv);
        void DeleteInvoice(int id);
    }
}
