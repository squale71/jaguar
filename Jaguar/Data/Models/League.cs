using System.Collections.Generic;

namespace Jaguar.Data.Models
{
    public class League
    {
        public int GameId { get; set; }
        public int Id { get; set; }
        public List<Member> Members { get; set; }
        public int ScoringPeriodId { get; set; }
        public int SeasonId { get; set; }
        public int SegmentId { get; set; }
        public Settings Settings { get; set; }
        public Status Status { get; set; }
        public List<Team> Teams { get; set; }
    }
}
