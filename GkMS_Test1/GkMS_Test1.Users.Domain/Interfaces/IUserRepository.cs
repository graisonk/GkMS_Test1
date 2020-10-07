using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        UserVM GetUser(int id);
        void AddUser(UserVM user);
        void ModifyUser(int id, UserVM user);
        void DeleteUser(int id);
    }
}
