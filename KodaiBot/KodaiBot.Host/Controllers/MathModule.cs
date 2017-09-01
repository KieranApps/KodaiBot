using System;
using System.Threading.Tasks;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class MathModule : ModuleBase
    {
        public MathModule(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("roll"),
            Alias("dice", "diceroll", "rng", "random"),
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
            Alias("calc", "cal", "calculate", "compute"),
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
