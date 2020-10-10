using GkMS_Test1.Domain.Core.Events;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GkMS_Test1.Users.Domain.Events
{
    public class UserEvent : Event
    {
        public int RefId { get; set; }
        public string Uname { get; set; }
        public UserEvent(int refid, string username)
        {
            RefId = refid;
            Uname = username;
        }
    }
}
