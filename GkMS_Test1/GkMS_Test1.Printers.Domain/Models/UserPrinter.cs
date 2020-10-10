using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Models
{
    public class UserPrinter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Ref_User Ref_User { get; set; }
        public int PrinterId { get; set; }
        [ForeignKey("PrinterId")]
        public virtual Printer Printer { get; set; }        

        [Display(Name = "Installation Date"), DataType(DataType.Date)]
        public DateTime DateInstall { get; set; }

        [Display(Name = "Contract Period (Months)"), Column(TypeName = "varchar(15)")]
        public string Period { get; set; }

        [DataType(DataType.Currency)]
        public double DepositAmt { get; set; }
        public int Status { get; set; }
    }
}
