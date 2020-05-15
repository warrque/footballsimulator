using FootballSimulator.Models;

namespace FootballSimulator.Handlers.Interfaces
{
    public interface IMatchHandler
    {
        void InitMatch(Match match);
        void MovePlayers(Match match);
        void ExecutePlayerAction(Match match);
    }
}
