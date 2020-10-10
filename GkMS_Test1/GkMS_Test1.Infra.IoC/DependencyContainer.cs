using MediatR;
using GkMS_Test1.Domain.Core.Bus;
using GkMS_Test1.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using GkMS_Test1.Users.Application.Interfaces;
using GkMS_Test1.Users.Application.Services;
using GkMS_Test1.Users.Domain.Interfaces;
using GkMS_Test1.Users.Data.Repository;
using GkMS_Test1.Users.Data.Context;
using GkMS_Test1.Users.Domain.Commands;
using GkMS_Test1.Users.Domain.CommandHandlers;
using GkMS_Test1.Printers.Application.Interfaces;
using GkMS_Test1.Printers.Application.Services;
using GkMS_Test1.Printers.Data.Repository;
using GkMS_Test1.Printers.Data.Context;
using GkMS_Test1.Printers.Domain.Events;
using GkMS_Test1.Printers.Domain.EventHandlers;
using GkMS_Test1.Printers.Domain.Interfaces;
using GkMS_Test1.Invoice.Application.Interfaces;
using GkMS_Test1.Invoice.Application.Services;
using GkMS_Test1.Invoice.Data.Repository;
using GkMS_Test1.Invoice.Domain.Interfaces;
using GkMS_Test1.Invoice.Data.Context;

namespace GkMS_Test1.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<PrinterEventHandler>();
            services.AddTransient<UserEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<PrinterEvent>, PrinterEventHandler>();
            services.AddTransient<IEventHandler<UserEvent>, UserEventHandler>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreatePrinterCommand, bool>, PrinterCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();

            //Application Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPrinterService, PrinterService>();
            services.AddTransient<IInvoiceService, InvoiceService>();

            //Data
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPrinterRepository, PrinterRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<UserDbContext>();
            services.AddTransient<PrinterDbContext>();
            services.AddTransient<InvoiceDbContext>();
        }
    }
}
