using System;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class ModuleBase : Discord.Commands.ModuleBase
    {
        internal readonly IServiceProvider ServiceProvider;
        internal readonly Logger Logger;

        public ModuleBase(IServiceProvider serviceProvider, Logger logger)
        {
            ServiceProvider = serviceProvider;
            Logger = logger;
        }

        internal T GetCommand<T>() where T : class
        {
            return (T) ServiceProvider.GetService(typeof(T));
        }
    }
}
