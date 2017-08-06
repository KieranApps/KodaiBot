using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodaiBot.Common.ConfigurationModel
{
    public class Configurator
    {
        public class Bot
        {
            public static string Name
                => GetAppSettingValue(Constants.Bot.Name);

            public static string Url
                => GetAppSettingValue(Constants.Bot.Url);

            public static string Prefix
                => GetAppSettingValue(Constants.Bot.Prefix);

            public static string Token
                => GetAppSettingValue(Constants.Bot.Token);
        }

        public class Database
        {
            public static string Host
                => GetAppSettingValue(Constants.Database.Host);

            public static string Port
                => GetAppSettingValue(Constants.Database.Port);

            public static string User
                => GetAppSettingValue(Constants.Database.User);

            public static string Password
                => GetAppSettingValue(Constants.Database.Password);
        }

        private static string GetAppSettingValue(string key)
        {
            var val = ConfigurationManager.AppSettings[key];

            if (val == null)
            {
                throw new IndexOutOfRangeException();
            }

            return val;
        }
    }
}
