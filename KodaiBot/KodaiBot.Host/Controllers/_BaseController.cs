using System;
using System.Threading.Tasks;
using Discord.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class BaseController : ModuleBase
    {
        internal readonly IServiceProvider ServiceProvider;
        internal readonly Logger Logger;

        public BaseController(IServiceProvider serviceProvider, Logger logger)
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
