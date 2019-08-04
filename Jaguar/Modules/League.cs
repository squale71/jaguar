using Discord.Commands;
using Discord_Bot_Application.App_Start;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jaguar.Modules
{
    public class League : ModuleBase<SocketCommandContext>
    {
        [Command("league")]
        public async Task LeagueAsync()
        {
            var baseAddress = new Uri("http://fantasy.espn.com/apis/v3/games/ffl/seasons");
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("Cookie", Configuration.Instance.GetBySection("Espn", "Cookie"));
                var result = await client.GetAsync("http://fantasy.espn.com/apis/v3/games/ffl/seasons/2019/segments/0/leagues/228841");

                result.EnsureSuccessStatusCode();

                var res = await result.Content.ReadAsStringAsync();

                await ReplyAsync(res.Substring(0, 1999));
            }
        }
    }
}
