﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class MathController : BaseController
    {
        public MathController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("roll"),
         Summary("Rolls the dice")]
        public async Task RollTheDice(
            [Summary("A maximum number for the dice to throw")] string number = ""
            )
        {
            var command = GetCommand<GetDicerollCommand>();
            command.MaxEyes = number;

            command.Execute();

            await ReplyAsync(command.Result);
        }

        [Command("solve"),
            Summary("Evaluates a mathmetical expression")]
        public async Task Calculate(
            [Summary("Mathmetical expression to solve"),
                Remainder] string exp
            )
        {
            var command = GetCommand<GetCalculationResultCommand>();
            command.Expression = exp;

            command.Execute();

            await ReplyAsync(command.Result);
        }
    }
}
