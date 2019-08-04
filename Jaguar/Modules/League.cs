using Discord.Commands;
using Jaguar.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Jaguar.Modules
{
    /// <summary>
    /// The league module. Fetches data given a specific league.
    /// </summary>
    public class League : ModuleBase<SocketCommandContext>
    {
        private readonly ILeagueApiRepository _leagueApiRepository;

        public League(ILeagueApiRepository leagueApiRepository)
        {
            _leagueApiRepository = leagueApiRepository;
        }

        [Command("league")]
        public async Task LeagueAsync()
        {
            var res = await _leagueApiRepository.GetLeague(2019, 228841);

            var list = string.Join(", ", res.Teams.Select(x => x.Nickname));

            await ReplyAsync(list);
        }
    }
}
