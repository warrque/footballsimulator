namespace FootballSimulator.Models
{
    /// <summary>
    /// Represents a match that is played or has been played
    /// </summary>
    public class Match
    {
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
        public Team Team1 { get; }
        public Team Team2 { get; }

        public Team AttackingTeam { get; set; }
        public FootballPlayer PlayerWithBall { get; set; }

        public Match(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
        }
    }
}
