using System.Collections.Generic;
using FootballSimulator.Constants;
using FootballSimulator.Factories.Interfaces;
using FootballSimulator.Handlers.Interfaces;
using FootballSimulator.Models;

namespace FootballSimulator.Factories
{
    public class TeamFactory : ITeamFactory
    {
        private readonly IRandomHandler _randomHandler;

        public TeamFactory(IRandomHandler randomHandler)
        {
            _randomHandler = randomHandler;
        }

        public Team CreateTeam(string name, int averageStrength)
        {
            return new Team
            {
                Name = name,
                Attackers = new List<FootballPlayer>
                {
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    }
                },
                Defenders = new List<FootballPlayer>
                {
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    }
                },
                MidFielders = new List<FootballPlayer>
                {
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    },
                    new FootballPlayer
                    {
                        BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                        SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                    }
                },
                Keeper = new FootballPlayer
                {
                    BallControl = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                    Passing = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                    GoalKeeping = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                    Tackles = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                    GoalScoring = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance),
                    SprintSpeed = averageStrength + _randomHandler.NextInt(TeamConstants.TeamStatVariance)
                }
            };
        }
    }
}
