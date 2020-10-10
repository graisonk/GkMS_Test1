using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Models
{
    public class PrinterRates
    {
        public int Id { get; set; }        
        public int PrinterId { get; set; }
        [ForeignKey("PrinterId")]
        public virtual Printer Printer { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Ref_User Ref_User { get; set; }
        public int ValFrom { get; set; }
        public int ValTo { get; set; }
        public double Rate { get; set; }   
    }
}
