using Jaguar.Data.Models;
using System.Threading.Tasks;

namespace Jaguar.Abstractions
{
    /// <summary>
    /// Exposes methods for getting league data in the database
    /// </summary>
    public interface ILeagueDbRepository
    {
        /// <summary>
        /// Given a league, creates it in the database.
        /// </summary>
        /// <param name="league">The league to add</param>
        Task AddLeague(League league);


        /// <summary>
        /// Gets the league based on id and year
        /// </summary>
        /// <param name="year"></param>
        /// <param name="id"></param>
        /// <returns>A league</returns>
        Task<League> GetLeague(int year, ulong id);
    }
}
