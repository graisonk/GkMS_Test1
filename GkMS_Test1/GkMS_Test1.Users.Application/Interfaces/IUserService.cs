using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
