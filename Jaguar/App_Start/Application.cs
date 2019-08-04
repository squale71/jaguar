using Discord;
using Discord.Commands;
using Discord_Bot_Application.Handlers;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net;
using Jaguar.Abstractions;
using Jaguar.Data.Repositories;
using Jaguar.Data;

namespace Discord_Bot_Application.App_Start
{
    public class Application
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private IMessageHandler _messageHandler;

        private Application() { }

        public static async Task Initialize()
        {
            var app = new Application();

            await app.RunBotAsync();
        }

        public async Task RunBotAsync()
        {
            await Log(new LogMessage(LogSeverity.Info, "INFO", $"Running in {Configuration.Instance.GetBySection("Environment", "Name")}"));

            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton<IMessageHandler, MessageHandler>()
                .AddTransient<ILeagueApiRepository, LeagueEspnRepository>()
                .AddTransient<ILeagueDbRepository, LeagueMongoRepository>()
                .AddTransient<MongoDbConnection>()
                .BuildServiceProvider();

            string botToken = Configuration.Instance.GetBySection("Discord", "Token");

            _client.Log += Log;

            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, botToken);

            await _client.StartAsync();

            await Task.Delay(-1);          
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleMessageAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleMessageAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;


            int argPos = 0;

            //TODO: Set your prefix here.
            if (message.HasStringPrefix("/bot ", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var res = await _commands.ExecuteAsync(context, argPos, _services);

                if (!res.IsSuccess)
                {
                    Console.WriteLine(res.ErrorReason);
                }
            }
            else
            {
                await _messageHandler.HandleUserMessage(message);
            }
        }
    }
}
