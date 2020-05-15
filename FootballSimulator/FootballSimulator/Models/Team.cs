using System.Collections.Generic;

namespace FootballSimulator.Models
{
    /// <summary>
    /// Represents a team of players
    /// </summary>
    public class Team
    {
        public string Name { get; set; }
        public FootballPlayer Keeper { get; set; }
        public List<FootballPlayer> Defenders { get; set; }
        public List<FootballPlayer> MidFielders { get; set; }
        public List<FootballPlayer> Attackers { get; set; }
    }
}
