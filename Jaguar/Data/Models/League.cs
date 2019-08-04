using System.Collections.Generic;

namespace Jaguar.Data.Models
{
    public class League
    {
        public ulong GameId { get; set; }
        public ulong Id { get; set; }
        public List<Member> Members { get; set; }
        public ulong ScoringPeriodId { get; set; }
        public ulong SeasonId { get; set; }
        public ulong SegmentId { get; set; }
        public Settings Settings { get; set; }
        public Status Status { get; set; }
        public List<Team> Teams { get; set; }
        public int Year { get; set; }
        public ulong GuildId { get; set; }
    }
}
