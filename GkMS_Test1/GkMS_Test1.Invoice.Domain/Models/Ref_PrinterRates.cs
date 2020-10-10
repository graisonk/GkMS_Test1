using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Invoice.Domain.Models
{
    public class Ref_PrinterRates
    {
        public int Id { get; set; }        
        public int PrinterId { get; set; }
        [ForeignKey("PrinterId")]
        public virtual Ref_Printer  Ref_Printer { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Ref_User Ref_User { get; set; }
        public int ValFrom { get; set; }
        public int ValTo { get; set; }
        public double Rate { get; set; }
        public int RefDbId { get; set; }
    }
}
