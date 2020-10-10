using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Domain.ViewModels
{
    public class PrinterSlabVM
    {
        public Printer Printer { get; set; }
        public List<PrinterRates> PrinterRates { get; set; }
        public string Del_List_Str { get; set; }
    }
}
