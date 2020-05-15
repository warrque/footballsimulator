using System.Collections.Generic;

namespace FootballSimulator.Constants
{
    public static class MatchConstants
    {
        //general information about the game
        public const int MinutesInGame = 90;
        public const int PointsWinner = 3;
        public const int PointsTie = 1;

        //goal keeping gets a multiplier to prevent unrealistic scores
        public const int GoalKeepingMultiplier = 5;
    }
}
