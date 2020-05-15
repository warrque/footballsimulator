using FootballSimulator.Models;

namespace FootballSimulator.Factories.Interfaces
{
    public interface ITeamFactory
    {
        Team CreateTeam(string name, int averageStrength);
    }
}
