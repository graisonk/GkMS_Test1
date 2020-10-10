using GkMS_Test1.Printers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Data.Context
{
    public class PrinterDbContext : DbContext
    {
        public PrinterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Printer> Printers { get; set; }
        public DbSet<UserPrinter> UserPrinters { get; set; }
        public DbSet<Ref_User> Ref_Users { get; set; }
        public DbSet<PrinterRates> PrinterRates { get; set; }        
    }
}
