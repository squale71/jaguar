using Discord.Commands;
using Jaguar.Abstractions;
using System.Threading.Tasks;

namespace Jaguar.Modules
{ 
    public class Register : ModuleBase<SocketCommandContext>
    {
        private readonly ILeagueDbRepository _leagueDbRepository;
        private readonly ILeagueApiRepository _leagueApiRepository;

        public Register(ILeagueDbRepository leagueDbRepository, ILeagueApiRepository leagueApiRepository)
        {
            _leagueDbRepository = leagueDbRepository;
            _leagueApiRepository = leagueApiRepository;
        }

        [Command("register")]
        public async Task RegisterAsync(int year, [Remainder]ulong leagueId)
        {
            var existingLeague = await _leagueDbRepository.GetLeague(year, leagueId);

            if (existingLeague != null)
            {
                await ReplyAsync("That league already exists with this channel");
            }

            else
            {
                var onlineLeague = await _leagueApiRepository.GetLeague(year, leagueId);

                if (onlineLeague != null)
                {
                    onlineLeague.Year = year;
                    onlineLeague.GuildId = Context.Guild.Id;
                    
                    await _leagueDbRepository.AddLeague(onlineLeague);

                    await ReplyAsync("That league has been registered to this discord channel.");
                }

                else
                {
                    await ReplyAsync("That league does not exist on ESPN.com, or you do not have access to it");
                }
            }
        }
    }
}
