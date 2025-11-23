using System;
using TournamentSimulation.Data;

namespace TournamentSimulation.Match
{
    public abstract class MatchControllerBase : IMatchController
    {
        private readonly Random _random;
        private readonly ExperienceData _experienceData;
        protected MatchControllerBase(ExperienceData experienceData)
        {
            _experienceData = experienceData ?? throw new ArgumentNullException(nameof(experienceData));
            _random = new Random();
        }
        public PlayerData Play(MatchData data)
        {
            DetermineMatchResult(data, out PlayerData winnerPlayer, out PlayerData loserPlayer);
            SetExperiences(winnerPlayer, loserPlayer);
            return loserPlayer;
        }
        private void SetExperiences(PlayerData winnerPlayer, PlayerData loserPlayer)
        {
            winnerPlayer.Experience += _experienceData.WinExperience;
            loserPlayer.Experience += _experienceData.LoserExperience;
        }


        protected virtual void DetermineMatchResult(MatchData matchData, out PlayerData winner, out PlayerData loser)
        {
            int playerAPoints = CalculatePlayerPoints(matchData.Player, matchData);
            int playerBPoints = CalculatePlayerPoints(matchData.Opponent, matchData);

            double playerAProbability = (double)playerAPoints / (playerAPoints + playerBPoints);
            if (_random.NextDouble() < playerAProbability)
            {
                winner = matchData.Player;
                loser = matchData.Opponent;
            }
            else
            {
                loser = matchData.Player;
                winner = matchData.Opponent;
            }
            Console.WriteLine(matchData);
            // if (playerBPoints < playerAPoints)
            // {
            //     winner = matchData.Player;
            //     loser = matchData.Opponent;
            // }
            // else
            // {
            //     loser = matchData.Player;
            //     winner = matchData.Opponent;
            // }
            // Console.WriteLine($"Winner: {winner} vs Loser: {loser}");
        }
        protected virtual int CalculatePlayerPoints(PlayerData playerData, MatchData matchData)
        {
            int points = 1;
            var opponent = matchData.Opponent;
            if (playerData != matchData.Player)
            {
                playerData = opponent;
                opponent = matchData.Player;
            }
            if (playerData.Hand == "left")
            {
                points += 2;
            }
            if (playerData.Experience > opponent.Experience)
            {
                points += 3;
            }
            var currentPlayerSurfaceSkill = playerData.Skills.TryGetValue(matchData.Surface, out var playerSp) ? playerSp : 0;
            var opponentPlayerSurfaceSkill = opponent.Skills.TryGetValue(matchData.Surface, out var opponentSp) ? opponentSp : 0;
            if (currentPlayerSurfaceSkill > opponentPlayerSurfaceSkill)
            {
                points += 4;
            }
            return points;
        }

    }
}