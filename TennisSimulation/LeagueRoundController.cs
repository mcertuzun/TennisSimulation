using System.Collections.Generic;
using System;
using TournamentSimulation.Data;
using TournamentSimulation.Enums;
using TournamentSimulation.Match;

namespace TournamentSimulation.Round
{
    public class LeagueRoundController : RoundControllerBase
    {
        private MatchData[,] Matches { get; set; }
        public override void PlayRounds()
        {
            Console.Write($" \n ++++++++++++++++++++++League ROUND++++++++++++++++++++++++ \n");
            PrepareMatches();
            PlayMatches();
        }
        private void PrepareMatches()
        {
            int numParticipants = PlayersData.Count;
            int numRounds = PlayersData.Count;
            int matchesPerRound = numRounds / 2;
            Matches = new MatchData[numRounds, matchesPerRound];
            for (int round = 0; round < numRounds; round++)
            {
                for (int match = 0; match < matchesPerRound; match++)
                {
                    int player = (round + match) % (numParticipants - 1);
                    int opponent = (numParticipants - 1 - match + round) % (numParticipants - 1);

                    if (match == 0)
                    {
                        opponent = numParticipants - 1;
                    }
                    Matches[round, match] =
                        new MatchData(PlayersData[player], PlayersData[opponent], SurfaceType);
                }
            }
        }
        private void PlayMatches()
        {
            foreach (var matchData in Matches)
            {
                MatchController.Play(matchData);
            }
        }
        public LeagueRoundController(SurfaceType surfaceType, List<PlayerData> playersData, IMatchController matchController) : base(surfaceType, playersData, matchController)
        {
        }
    }
}