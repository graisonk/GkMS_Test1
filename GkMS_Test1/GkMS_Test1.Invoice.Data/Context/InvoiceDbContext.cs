using GkMS_Test1.Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Invoice.Data.Context
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Ref_User> Users { get; set; }
        public DbSet<Ref_Printer> Printers { get; set; }
        public DbSet<Ref_PrinterRates> PrinterRates { get; set; }
        public DbSet<Ref_UserPrinter> UserPrinters { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
    }
}
