namespace FootballSimulator.Models
{
    /// <summary>
    /// Represents a player on the football field
    /// </summary>
    public class FootballPlayer
    {
        public int BallControl { get; set; }
        public int Passing { get; set; }
        public int GoalKeeping { get; set; }
        public int Tackles { get; set; }
        public int GoalScoring { get; set; }
        public int SprintSpeed { get; set; }

        public int Position { get; set; }
    }
}
