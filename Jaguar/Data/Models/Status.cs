namespace Jaguar.Data.Models
{
    public class Status
    {
        public int CurrentMatchupPeriod { get; set; }
        public bool IsActive { get; set; }
        public int LatestScoringPeriod { get; set; }
    }
}
