using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Invoice.Domain.Events;
using GkMS_Test1.Invoice.Domain.Interfaces;
using GkMS_Test1.Invoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GkMS_Test1.Invoice.Domain.EventHandlers
{
    public class RateChangeEventHandler : IEventHandler<RateChangeEvent>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public RateChangeEventHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public Task Handle(RateChangeEvent @event)
        {
            _invoiceRepository.ModifyRates(new Ref_PrinterRates()
            {
                Id = @event.RefId,
                ValFrom = @event.ValFrom,
                ValTo = @event.ValTo,
                Rate = @event.Rate
            });
            return Task.CompletedTask;
        }
    }
}
