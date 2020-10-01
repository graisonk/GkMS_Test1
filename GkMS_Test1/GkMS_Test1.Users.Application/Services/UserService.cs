using GkMS_Test1.Users.Application.Interfaces;
using GkMS_Test1.Users.Domain.Interfaces;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
