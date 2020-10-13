using GkMS_Test1.Invoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Invoice.Application.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Invoices> GetInvoices();
        Invoices GetInvoice(int id);
        void AddInvoice(Invoices Inv);
        void ModInvoice(int id, Invoices Inv);
        void DelInvoice(int id);

        List<Ref_User> UserSearch(string pattern);
        List<Ref_PrinterRates> PrinterRates(int userId, int ptrId);
    }
}
