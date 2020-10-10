using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Users.Domain.Commands;
using GkMS_Test1.Users.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GkMS_Test1.Users.Domain.CommandHandlers
{
    public class UserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public UserCommandHandler(IEventBus  eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _eventBus.Publish(new UserEvent(request.RefId, request.Uname));
            return Task.FromResult(true);
        }
    }
}
