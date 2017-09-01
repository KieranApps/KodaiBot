using System;
using Discord.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class AdminModule : ModuleBase
    {
        public AdminModule(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Group("clean")]
        public class CleanController : ModuleBase
        {
            public CleanController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
            {
            }
        }
    }
}
