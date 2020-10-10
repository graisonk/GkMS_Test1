using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Application.Models
{
    public class UPrinterDto
    {
        public int UserId { get; set; }
        public int PrinterId { get; set; }
        public bool IsAssigned { get; set; }
    }
}
