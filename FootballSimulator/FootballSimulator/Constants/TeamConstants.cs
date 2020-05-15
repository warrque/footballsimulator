using System;
using System.Collections.Generic;
using System.Text;

namespace FootballSimulator.Constants
{
    public static class TeamConstants
    {
        //positions on the play field. play field is 500 units long. Each of the goals are at opposite side.
        public const int Team1GoalPosition = 500;
        public const int Team2GoalPosition = 0;
        public static readonly List<int> Team1Positions = new List<int> { 250, 350, 450, 500 };
        public static readonly List<int> Team2Positions = new List<int> { 250, 150, 50, 0 };

        public const int TeamStatVariance = 10;
    }
}
