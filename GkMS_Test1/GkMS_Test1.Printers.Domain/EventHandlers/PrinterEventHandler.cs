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
    public class PrinterEventHandler : IEventHandler<PrinterEvent>
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterEventHandler(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }
        public Task Handle(PrinterEvent @event)
        {
            _printerRepository.Add(new UserPrinter()
            {
                UserId = @event.UserId,
                PrinterId = @event.PrinterId,
                DateInstall = DateTime.Now,
                DepositAmt = 0,
                Status = 1
            });

            return Task.CompletedTask;
        }
    }
}
