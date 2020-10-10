using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Invoice.Domain.Models
{
    public class Ref_Printer
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar(300)"), Display(Name = "Printer Name")]
        public string Name { get; set; }
        [Display(Name = "Serial No."), Column(TypeName = "varchar(50)")]
        public string Serial { get; set; }
        [Display(Name = "HSN Code"), Column(TypeName = "varchar(10)")]
        public string Hsn { get; set; }
        [Display(Name = "CGST %")]
        public double Cgst { get; set; }
        [Display(Name = "SGST %")]
        public double Sgst { get; set; }
        [Column(TypeName = "varchar(100)"), Display(Name = "Printer Searchable Name")]
        public string SearchableName { get; set; }
        public int RefDbId { get; set; }
    }
}
