using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Invoice.Domain.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId"), Display(Name = "User")]
        public virtual Ref_User Ref_User { get; set; }

        [Display(Name = "Printer")]
        public int PrinterId { get; set; }
        [ForeignKey("PrinterId"), Display(Name = "Printer")]
        public virtual Ref_Printer Ref_Printer { get; set; }

        [Display(Name = "Invoice No.")]
        public int InvNo { get; set; }
        
        [Display(Name = "Previous Reading")]
        public int ReadingPrev { get; set; }

        [Display(Name = "Current Reading")]
        public int ReadingCurr { get; set; }        

        [DataType(DataType.Currency), Display(Name = "Total Amount")]
        public double AmtTotal { get; set; }        
    }
}
