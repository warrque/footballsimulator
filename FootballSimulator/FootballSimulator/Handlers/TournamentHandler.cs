using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballSimulator.Constants;
using FootballSimulator.Handlers.Interfaces;
using FootballSimulator.Models;

namespace FootballSimulator.Handlers
{
    public class TournamentHandler : ITournamentHandler
    {
        public List<TournamentTeamResult> GetTournamentResults(List<Team> teams, List<Match> matchResults)
        {
            //get all the tournament results ready
            var tournamentResultMapping = teams.ToDictionary(team => team, team => new TournamentTeamResult(team));
            
            //for each match
            foreach (var matchResult in matchResults)
            {
                //for both teams apply the goals
                tournamentResultMapping[matchResult.Team1].GoalsMade += matchResult.Team1Goals;
                tournamentResultMapping[matchResult.Team1].GoalDifference += matchResult.Team1Goals - matchResult.Team2Goals;
                tournamentResultMapping[matchResult.Team1].GoalsTaken += matchResult.Team2Goals;

                tournamentResultMapping[matchResult.Team2].GoalsMade += matchResult.Team2Goals;
                tournamentResultMapping[matchResult.Team2].GoalDifference += matchResult.Team2Goals - matchResult.Team1Goals;
                tournamentResultMapping[matchResult.Team2].GoalsTaken += matchResult.Team1Goals;

                //check which team wins the match
                if (matchResult.Team1Goals > matchResult.Team2Goals)
                {
                    tournamentResultMapping[matchResult.Team1].Points += MatchConstants.PointsWinner;
                }
                else if (matchResult.Team1Goals < matchResult.Team2Goals)
                {
                    tournamentResultMapping[matchResult.Team2].Points += MatchConstants.PointsWinner;
                }
                else
                {
                    tournamentResultMapping[matchResult.Team1].Points += MatchConstants.PointsTie;
                    tournamentResultMapping[matchResult.Team2].Points += MatchConstants.PointsTie;
                }
            }
            
            //order by tournament scoring based on a implementation of IComparable
            return tournamentResultMapping.Values.OrderBy(x => x).ToList();
        }
    }
}
