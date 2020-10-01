using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.Users.Domain.Models
{
    public class Personal
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Display(Name = "Billing Address"), Column(TypeName = "varchar(300)")]
        public string Address_Bill { get; set; }

        [Display(Name = "Installation Address"), Column(TypeName = "varchar(300)")]
        public string Address_Install { get; set; }

        [Required, Phone, Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}
