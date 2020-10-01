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

            //Domain Commands
            services.AddTransient<IRequestHandler<CreatePrinterCommand, bool>, PrinterCommandHandler>();

            //Application Services
            services.AddTransient<IUserService, UserService>();

            //Data
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserDbContext>();
        }
    }
}
