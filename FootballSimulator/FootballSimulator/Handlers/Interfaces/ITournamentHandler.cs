using System;
using System.Collections.Generic;
using System.Text;
using FootballSimulator.Models;

namespace FootballSimulator.Handlers.Interfaces
{
    public interface ITournamentHandler
    {
        List<TournamentTeamResult> GetTournamentResults(List<Team> teams, List<Match> matchResults);
    }
}
