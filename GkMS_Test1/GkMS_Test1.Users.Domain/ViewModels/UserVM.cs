using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        public Personal Personal { get; set; }
    }
}
