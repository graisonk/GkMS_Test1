using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Printers.Domain.Commands;
using GkMS_Test1.Printers.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GkMS_Test1.Printers.Domain.CommandHandlers
{
    public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public UpdateRateCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new RateChangeEvent(request.RefId, request.ValFrom, request.ValTo, request.Rate));
            return Task.FromResult(true);
        }
    }
}
