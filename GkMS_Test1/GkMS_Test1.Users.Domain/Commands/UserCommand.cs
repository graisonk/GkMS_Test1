using GkMS_Test1.Domain.Core.Commands;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public int RefId { get; set; }        
        public string Uname { get; set; }
    }
}
