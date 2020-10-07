using GkMS_Test1.Users.Application.Models;
using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        UserVM GetUser(int id);
        void AddUser(UserVM user);
        void ModUser(int id, UserVM user);
        void DelUser(int id);
        void AssignPrinter(UserPrinter userPrinter);
    }
}
