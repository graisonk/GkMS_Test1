using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(int refid, string username)
        {
            RefId = refid;
            Uname = username;
        }
    }
}
