using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Models.DTO
{
    public class UserPrinterDto
    {
        public int UserId { get; set; }
        public int PrinterId { get; set; }
        public bool IsAssigned { get; set; }
    }
}
