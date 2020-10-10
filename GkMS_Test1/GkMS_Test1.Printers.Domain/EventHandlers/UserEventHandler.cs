using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Printers.Domain.Events;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GkMS_Test1.Printers.Domain.EventHandlers
{
    public class UserEventHandler : IEventHandler<UserEvent>
    {
        private readonly IPrinterRepository _printerRepository;

        public UserEventHandler(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }
        public Task Handle(UserEvent @event)
        {
            _printerRepository.UpdateRefUser(new Ref_User()
            {
                Id = @event.RefId,
                Name = @event.Uname
            });

            return Task.CompletedTask;
        }
    }
}
