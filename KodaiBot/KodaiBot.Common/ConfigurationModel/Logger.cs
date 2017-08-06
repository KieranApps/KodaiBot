using System;
using System.Threading.Tasks;
using Discord;

namespace KodaiBot.Common.ConfigurationModel
{
    public class Logger
    {
        public Task Log(string message, string source, LogSeverity severity = LogSeverity.Info, Exception exception = null)
        {
            return Log(new LogMessage(severity, source ?? Configurator.Bot.Name, message, exception));
        }

        public Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            //ToDo: Add database connection to store logs.
            return Task.CompletedTask;
        }
    }
}
