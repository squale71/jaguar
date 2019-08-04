using Discord.Commands;
using System.Threading.Tasks;

namespace Discord_Bot_Application.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync($"Hello World!");
        }
    }
}
