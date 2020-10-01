﻿using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Users.Application.Interfaces;
using GkMS_Test1.Users.Application.Models;
using GkMS_Test1.Users.Domain.Commands;
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
        private readonly IEventBus _eventBus;

        public UserService(IUserRepository userRepository, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void AssignPrinter(UserPrinter userPrinter)
        {
            var createPrinterCommand = new CreatePrinterCommand(userPrinter.UserId, userPrinter.PrinterId,userPrinter.IsAssigned);
            _eventBus.SendCommand(createPrinterCommand);
        }        
    }
}
