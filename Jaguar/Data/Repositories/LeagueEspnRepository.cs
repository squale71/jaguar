using System.Collections.Generic;
using System.Threading.Tasks;
using Discord_Bot_Application.App_Start;
using Jaguar.Abstractions;
using Jaguar.Data.Models;

namespace Jaguar.Data.Repositories
{
    /// <summary>
    /// An ESPN implementation of the <seealso cref="ILeagueApiRepository"/>
    /// </summary>
    public class LeagueEspnRepository : HttpRepository, ILeagueApiRepository
    {
        public Task<League> GetLeague(int year, ulong id)
        {
            var headers = new Dictionary<string, string>()
            {
                {
                    "Cookie", Configuration.Instance.GetBySection("Espn", "Cookie")
                }
            };

            return GetData<League>("http://fantasy.espn.com/apis/v3/games/ffl/seasons", $"/{year}/segments/0/leagues/{id}", headers);
        }
    }
}
