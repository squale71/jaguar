using System.Collections.Generic;

namespace Jaguar.Data.Models
{
    public class Team
    {
        public string Abbrev { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string Nickname { get; set; }
        public List<string> Owners { get; set; }
    }
}
