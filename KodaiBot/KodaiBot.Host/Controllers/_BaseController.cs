using System;
using System.Threading.Tasks;
using Discord.Audio;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
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

        internal Task<IAudioClient> GetAudioClient()
        {
            var command = GetCommand<SummonAudioClient>();
            command.User = Context.User;

            command.Execute();

            return command.Result;
        }
    }
}
