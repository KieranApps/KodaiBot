using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Discord.Commands;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer;
using Microsoft.Extensions.DependencyInjection;
using KodaiBot.RepositoryLayer.Interfaces;
using KodaiBot.BusinessLayer;
using KodaiBot.BusinessLayer.Commands;

namespace KodaiBot.Host
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<DiscordProxy>()
                .EstablishClientConnection().GetAwaiter().GetResult();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Mapping profiles
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DataToIntermediate());
                cfg.AddProfile(new IntermediateToData());
                cfg.AddProfile(new IntermediateToDomain());
                cfg.AddProfile(new DomainToIntermediate());
            }).CreateMapper());
            
            // Discord services
            services.AddTransient<DbEntities>();
            services.AddTransient<DiscordProxy>();
            services.AddTransient<Logger>();
            services.AddTransient<CommandService>();

            // Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Commands
            services.AddTransient<GetCurrentTimeCommand>();


        }
    }
}
