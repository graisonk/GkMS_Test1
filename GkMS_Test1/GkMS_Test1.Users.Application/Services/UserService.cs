using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Users.Application.Interfaces;
using GkMS_Test1.Users.Application.Models;
using GkMS_Test1.Users.Domain.Commands;
using GkMS_Test1.Users.Domain.Interfaces;
using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _eventBus;

        public UserService(IUserRepository userRepository, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
        }

        public void AssignPrinter(UPrinterDto userPrinter)
        {
            var createPrinterCommand = new CreatePrinterCommand(userPrinter.UserId, userPrinter.PrinterId, userPrinter.IsAssigned);
            _eventBus.SendCommand(createPrinterCommand);
        }
        public void UpdProfile(User profile)
        {
            var updateUserCommand = new UpdateUserCommand(profile.Id, profile.Name);
            _eventBus.SendCommand(updateUserCommand);
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }        
        public UserVM GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public void AddUser(UserVM user)
        {
            _userRepository.AddUser(user);
        }

        public void ModUser(int id, UserVM user)
        {
            _userRepository.ModifyUser(id, user);
        }

        public void DelUser(int id)
        {
            _userRepository.DeleteUser(id);
        }        
    }
}
