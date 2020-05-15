using FootballSimulator.Models;

namespace FootballSimulator.Handlers.Interfaces
{
    public interface IBallHandler
    {
        bool PassBall(FootballPlayer playerWithBall, FootballPlayer teamPlayer, FootballPlayer opponentPlayer);
        bool PassPlayer(FootballPlayer playerWithBall, FootballPlayer opponentPlayer);
        bool ScoreGoal(FootballPlayer playerWithBall, FootballPlayer opponentGoalKeeper);
    }
}
