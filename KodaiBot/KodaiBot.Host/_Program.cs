using AutoMapper;
using Discord.Commands;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer;
using Microsoft.Extensions.DependencyInjection;
using KodaiBot.RepositoryLayer.Interfaces;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.BusinessLayer.Helpers;
using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Repositories;

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
            services.AddSingleton(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DataToIntermediate>();
                    cfg.AddProfile<IntermediateToData>();
                    cfg.AddProfile<IntermediateToDomain>();
                    cfg.AddProfile<DomainToIntermediate>();
                }).CreateMapper());

            // Discord services
            services.AddTransient<DiscordProxy>();
            services.AddTransient<Logger>();
            services.AddTransient<CommandService>();

            // Repositories
            services.AddSingleton<DbEntities>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAliasRepository, AliasRepository>();
            services.AddTransient<IGuildRepository, GuildRepository>();
            services.AddTransient<ISnapshotRepository, SnapshotRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Commands
            services.AddTransient<GetCurrentTimeCommand>();
            services.AddTransient<GetDicerollCommand>();

            // Helpers
            services.AddTransient<AliasHelper>();
        }
    }
}
