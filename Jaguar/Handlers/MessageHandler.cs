using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Discord_Bot_Application.Handlers
{
    public class MessageHandler : IMessageHandler
    {
        private DiscordSocketClient _client;
        private CommandService _commands;

        private IMessageChannel _channel;

        public MessageHandler(DiscordSocketClient client, CommandService commands)
        {
            _client = client;
            _commands = commands;
        }

        public async Task HandleUserMessage(SocketUserMessage message)
        {
            _channel = _client.GetChannel(message.Channel.Id) as IMessageChannel;
        }

    }

    public interface IMessageHandler
    {
        Task HandleUserMessage(SocketUserMessage message);
    }
}
