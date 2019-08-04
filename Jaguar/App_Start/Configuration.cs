using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Discord_Bot_Application.App_Start
{
    public class Configuration
    {
        private static Configuration _instance;

        private IConfigurationRoot _config;

        private Configuration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables("DISCORDBOT_");

            _config = builder.Build();
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
                return _instance;
            }
        }


        public string Get(string key)
        {
            return _config[$"{key}"];
        }

        public string GetBySection(string section, string key)
        {
            return _config.GetSection(section)[key];
        }
    }
}
