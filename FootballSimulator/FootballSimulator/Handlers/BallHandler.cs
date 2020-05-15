using System;
using FootballSimulator.Constants;
using FootballSimulator.Handlers.Interfaces;
using FootballSimulator.Models;

namespace FootballSimulator.Handlers
{
    public class BallHandler : IBallHandler
    {
        private readonly IRandomHandler _randomHandler;

        public BallHandler(IRandomHandler randomHandler)
        {
            _randomHandler = randomHandler;
        }

        public bool PassBall(FootballPlayer playerWithBall, FootballPlayer teamPlayer, FootballPlayer opponentPlayer)
        {
            //player with ball shoots ball towards team player. opponent player is defending against this action
            var teamValue = (playerWithBall.Passing + teamPlayer.BallControl) / 2;
            var chanceToPass = (double) teamValue / (teamValue + opponentPlayer.Tackles);

            return chanceToPass > _randomHandler.NextDouble();
        }

        public bool PassPlayer(FootballPlayer playerWithBall, FootballPlayer opponentPlayer)
        {
            //player with ball uses a maneuver to skilfully outplay the opponent player
            var chanceToPass = (double) playerWithBall.BallControl /
                               (playerWithBall.BallControl + opponentPlayer.Tackles);

            return chanceToPass > _randomHandler.NextDouble();
        }

        public bool ScoreGoal(FootballPlayer playerWithBall, FootballPlayer opponentGoalKeeper)
        {
            //player with ball attempts a shot at goal
            var chanceToScore = (double) playerWithBall.GoalScoring /
                                (playerWithBall.GoalScoring + opponentGoalKeeper.GoalKeeping * MatchConstants.GoalKeepingMultiplier);

            return chanceToScore > _randomHandler.NextDouble();
        }
    }
}
