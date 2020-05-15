using System.Collections.Generic;
using System.Linq;
using FootballSimulator.Controllers.Interfaces;
using FootballSimulator.Factories.Interfaces;
using FootballSimulator.Handlers.Interfaces;
using FootballSimulator.Models;
using FootballSimulator.Simulators.Interfaces;
using FootballSimulator.Views.Interfaces;

namespace FootballSimulator.Controllers
{
    public class TournamentController : ITournamentController
    {
        private readonly ITeamFactory _teamFactory;
        private readonly IGameSimulator _gameSimulator;
        private readonly ITournamentHandler _tournamentHandler;
        private readonly ITournamentView _tournamentView;

        public TournamentController(
            ITeamFactory teamFactory, 
            IGameSimulator gameSimulator, 
            ITournamentHandler tournamentHandler, 
            ITournamentView tournamentView)
        {
            _teamFactory = teamFactory;
            _gameSimulator = gameSimulator;
            _tournamentHandler = tournamentHandler;
            _tournamentView = tournamentView;
        }

        public void PlayTournament()
        {
            //create teams
            var team1 = _teamFactory.CreateTeam("Team1", 70);
            var team2 = _teamFactory.CreateTeam("Team2", 60);
            var team3 = _teamFactory.CreateTeam("Team3", 50);
            var team4 = _teamFactory.CreateTeam("Team4", 40);

            var teams = new List<Team> { team1, team2, team3, team4 };

            //create matches
            var matches = new List<(Team, Team)>
            {
                (team1, team2),
                (team1, team3),
                (team1, team4),
                (team2, team3),
                (team2, team4),
                (team3, team4),
            };

            //play matches
            var matchResults = matches.Select(match => _gameSimulator.SimulateMatch(match.Item1, match.Item2)).ToList();

            //collect tournament results
            var tournamentResults = _tournamentHandler.GetTournamentResults(teams, matchResults);

            //show results
            _tournamentView.ShowResult(matchResults, tournamentResults);
        }
    }
}
