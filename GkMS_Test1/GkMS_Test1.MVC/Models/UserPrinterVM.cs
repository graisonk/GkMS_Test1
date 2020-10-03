using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Models
{
    public class UserPrinterVM
    {
        public int UserId { get; set; }
        public int PrinterId { get; set; }
        public bool IsAssigned { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Remarks { get; set; }
    }
}
