using Jaguar.Data.Models;
using System.Threading.Tasks;

namespace Jaguar.Abstractions
{
    /// <summary>
    /// Repository for getting league data
    /// </summary>
    public interface ILeagueApiRepository
    {
        /// <summary>
        /// Given an id, fetches a league
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<League> GetLeague(int year, ulong id);
    }
}
