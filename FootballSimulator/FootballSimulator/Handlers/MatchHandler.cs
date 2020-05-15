using System;
using System.Collections.Generic;
using System.Linq;
using FootballSimulator.Constants;
using FootballSimulator.Handlers.Interfaces;
using FootballSimulator.Models;

namespace FootballSimulator.Handlers
{
    public class MatchHandler : IMatchHandler
    {
        private readonly IRandomHandler _randomHandler;
        private readonly IBallHandler _ballHandler;

        public MatchHandler(IRandomHandler randomHandler, IBallHandler ballHandler)
        {
            _randomHandler = randomHandler;
            _ballHandler = ballHandler;
        }

        public void InitMatch(Match match)
        {
            //teams get placed at their starting position
            ResetTeam(match.Team1, TeamConstants.Team1Positions);
            ResetTeam(match.Team2, TeamConstants.Team2Positions);

            //a coin toss is made, the team that wins gets the ball first
            var coinToss = _randomHandler.NextDouble();
            GiveBall(match, coinToss >= 0.5 ? match.Team1 : match.Team2);
        }

        private void GiveBall(Match match, Team team)
        {
            //give the ball to a random attacker on the selected team
            var index = _randomHandler.NextInt(team.Attackers.Count);
            match.PlayerWithBall = team.Attackers[index];
            match.AttackingTeam = team;
        }

        private void ResetTeam(Team team, List<int> positions)
        {
            //starting positions are set for each player
            foreach (var player in team.Attackers)
            {
                player.Position = positions[0];
            }
            foreach (var player in team.MidFielders)
            {
                player.Position = positions[1];
            }
            foreach (var player in team.Defenders)
            {
                player.Position = positions[2];
            }

            team.Keeper.Position = positions[3];
        }

        public void MovePlayers(Match match)
        {
            //each team moves their players
            MovePlayersInTeam(match, match.Team1, TeamConstants.Team2GoalPosition);
            MovePlayersInTeam(match, match.Team2, TeamConstants.Team1GoalPosition);
        }

        private void MovePlayersInTeam(Match match, Team team, int opponentGoalPosition)
        {
            //if the current team holds the ball, the player with the ball moves forwards towards the goal
            if (match.AttackingTeam == team)
            {
                MovePlayerWithBall(match, opponentGoalPosition);
            }

            //other players move in relative position to the ball
            MoveTeam(match, team, opponentGoalPosition);
        }
        
        private void MovePlayerWithBall(Match match, int opponentGoalPosition)
        {
            //player with ball always moves towards the goal
            if (opponentGoalPosition > 0)
            {
                match.PlayerWithBall.Position += match.PlayerWithBall.SprintSpeed;
            }
            else
            {
                match.PlayerWithBall.Position -= match.PlayerWithBall.SprintSpeed;
            }

            //correct position so the player doesn't go out of bounds
            match.PlayerWithBall.Position = CorrectPosition(match.PlayerWithBall.Position, opponentGoalPosition);
        }
        
        private int CorrectPosition(int currentPosition, int opponentGoalPosition)
        {
            //make sure players don't go out of bounds
            if (opponentGoalPosition > 0)
            {
                return currentPosition > opponentGoalPosition ? opponentGoalPosition : currentPosition;
            }

            return currentPosition < opponentGoalPosition ? opponentGoalPosition : currentPosition;
        }

        private void MoveTeam(Match match, Team team, int opponentGoalPosition)
        {
            int attackerTargetPosition, defenderTargetPosition;
            
            //decide target positions for attackers and defenders
            if (opponentGoalPosition > 0)
            {
                attackerTargetPosition = match.PlayerWithBall.Position + match.PlayerWithBall.Passing;
                defenderTargetPosition = match.PlayerWithBall.Position - match.PlayerWithBall.Passing;
            }
            else
            {
                attackerTargetPosition = match.PlayerWithBall.Position - match.PlayerWithBall.Passing;
                defenderTargetPosition = match.PlayerWithBall.Position + match.PlayerWithBall.Passing;
            }
            
            //correct positions to not go out of bounds
            attackerTargetPosition = CorrectPosition(attackerTargetPosition, opponentGoalPosition);
            defenderTargetPosition = CorrectPosition(defenderTargetPosition, opponentGoalPosition);
            
            //move maximum passing range from player holding ball
            MovePlayersTowardTarget(team.Attackers, attackerTargetPosition);
            MovePlayersTowardTarget(team.MidFielders, match.PlayerWithBall.Position);
            MovePlayersTowardTarget(team.Defenders, defenderTargetPosition);
        }

        private void MovePlayersTowardTarget(List<FootballPlayer> players, int targetPosition)
        {
            foreach (var player in players)
            {
                //the player will always move towards the goal
                if (targetPosition > player.Position)
                {
                    player.Position += player.SprintSpeed;
                }
                else
                {
                    player.Position -= player.SprintSpeed;
                }

                //making sure not to go out of bounds
                if (player.Position < TeamConstants.Team2GoalPosition)
                {
                    player.Position = TeamConstants.Team2GoalPosition;
                }
                else if (player.Position > TeamConstants.Team1GoalPosition)
                {
                    player.Position = TeamConstants.Team1GoalPosition;
                }
            }
        }

        private List<FootballPlayer> GetTeamPlayers(Team team)
        {
            //get all team players that can move
            var players = new List<FootballPlayer>();
            players.AddRange(team.Attackers);
            players.AddRange(team.MidFielders);
            players.AddRange(team.Defenders);
            return players;
        }

        private void ExecuteGoalAttempt(Match match, Team opponentTeam)
        {
            //get goal keeper
            var goalKeeper = opponentTeam.Keeper;

            //attempt to shoot at goal
            var success = _ballHandler.ScoreGoal(match.PlayerWithBall, goalKeeper);
            if (success)
            {
                //goal was a success, add points for the team
                if (match.AttackingTeam == match.Team1)
                {
                    match.Team1Goals++;
                }
                else
                {
                    match.Team2Goals++;
                }

                //reset the playing field and give the ball to the opponent
                ResetTeam(match.Team1, TeamConstants.Team1Positions);
                ResetTeam(match.Team2, TeamConstants.Team2Positions);
                GiveBall(match, opponentTeam);
            }
            else
            {
                //the goal was a failure, the goalkeeper gets the ball
                match.PlayerWithBall = goalKeeper;
                match.AttackingTeam = opponentTeam;
            }
        }

        public void ExecutePlayerAction(Match match)
        {
            //get goal position
            var opponentGoalPosition = (match.AttackingTeam == match.Team1)
                ? TeamConstants.Team2GoalPosition
                : TeamConstants.Team1GoalPosition;

            //get the defending team
            var opponentTeam = (match.AttackingTeam == match.Team1) ? match.Team2 : match.Team1;

            //get all team players that can receive a pass
            var attackingPlayers = GetTeamPlayers(match.AttackingTeam);
            var validPlayers = (opponentGoalPosition) > 0 
                ? attackingPlayers.Where(x => x.Position > match.PlayerWithBall.Position).ToList() 
                : attackingPlayers.Where(x => x.Position < match.PlayerWithBall.Position).ToList();
            
            //if shot at goal can be taken
            if (Math.Abs(match.PlayerWithBall.Position - opponentGoalPosition) < match.PlayerWithBall.GoalScoring)
            {
                //try making a goal
                ExecuteGoalAttempt(match, opponentTeam);
                return;
            }

            //get the opponent that is closest
            var closestOpponent = GetTeamPlayers(opponentTeam).OrderBy(x => Math.Abs(x.Position - match.PlayerWithBall.Position)).First();

            if (validPlayers.Count > 0)
            {
                //if a pass can be given, get a random player to pass the ball to.
                var index = _randomHandler.NextInt(validPlayers.Count);
                var success = _ballHandler.PassBall(match.PlayerWithBall, validPlayers[index], closestOpponent);
                if (success)
                {
                    //passing the ball was a success, the receiving player now has the ball
                    match.PlayerWithBall = validPlayers[index];
                }
                else
                {
                    //passing the ball was a failure, intercepting opponent player now has the ball
                    match.PlayerWithBall = closestOpponent;
                    match.AttackingTeam = opponentTeam;
                }
            }
            else if (Math.Abs(match.PlayerWithBall.Position - closestOpponent.Position) < closestOpponent.Tackles)
            {
                //the player needs to skilfully pass the opponent player
                var success = _ballHandler.PassPlayer(match.PlayerWithBall, closestOpponent);
                if (!success)
                {
                    //it was a failure. opponent player has the ball
                    match.PlayerWithBall = closestOpponent;
                    match.AttackingTeam = opponentTeam;
                }
            }
        }
    }
}
