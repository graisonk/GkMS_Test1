using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GkMS_Test1.Users.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar(30)")]
        public string Name { get; set; }
        [Display(Name = "GST No."), Column(TypeName = "varchar(20)")]
        public string GstNo { get; set; }

        [Display(Name = "PAN No."), Column(TypeName = "varchar(20)")]
        public string PanNo { get; set; }
    }
}
