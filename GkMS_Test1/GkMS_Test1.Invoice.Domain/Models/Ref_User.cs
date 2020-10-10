using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Invoice.Domain.Models
{
    public class Ref_User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar(30)")]
        public string Name { get; set; }
        [Display(Name = "GST No."), Column(TypeName = "varchar(20)")]
        public string GstNo { get; set; }

        [Display(Name = "PAN No."), Column(TypeName = "varchar(20)")]
        public string PanNo { get; set; }
        public int RefDbId { get; set; }
    }
}
