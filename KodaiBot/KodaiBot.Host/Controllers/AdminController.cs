using System;
using Discord.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Group("clean")]
        public class CleanController : BaseController
        {
            public CleanController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
            {
            }
        }
    }
}
