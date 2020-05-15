using System;

namespace FootballSimulator.Models
{
    /// <summary>
    /// Represents a tournament result of a specific team
    /// </summary>
    public class TournamentTeamResult : IComparable<TournamentTeamResult>
    {
        public Team Team { get; }
        public int Points { get; set; }
        public int GoalDifference { get; set; }
        public int GoalsMade { get; set; }
        public int GoalsTaken { get; set; }

        public TournamentTeamResult(Team team)
        {
            Team = team;
        }

        public int CompareTo(TournamentTeamResult otherTeamResult)
        {
            //higher points is better
            if (Points != otherTeamResult.Points)
                return otherTeamResult.Points.CompareTo(Points);

            //higher goal difference is better
            if (GoalDifference != otherTeamResult.GoalDifference)
                return otherTeamResult.GoalDifference.CompareTo(GoalDifference);

            //higher goals made is better
            if (GoalsMade != otherTeamResult.GoalsMade)
                return otherTeamResult.GoalsMade.CompareTo(GoalsMade);

            //lower goals taken is better
            if (GoalsTaken != otherTeamResult.GoalsTaken)
                return GoalsTaken.CompareTo(otherTeamResult.GoalsTaken);

            return 0;
        }
    }
}
