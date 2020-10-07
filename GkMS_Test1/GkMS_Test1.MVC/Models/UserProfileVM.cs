using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Models
{
    public class UserProfileVM
    {
        public User User { get; set; }
        public Personal Personal { get; set; }
        public List<UserPrinter> UserPrinters { get; set; }
    }
}
