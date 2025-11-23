using System.Collections.Generic;
using System;
using TournamentSimulation.Data;
using TournamentSimulation.Enums;
using TournamentSimulation.Match;

namespace TournamentSimulation.Round
{
    public class EliminationRoundController : RoundControllerBase
    {
        private List<MatchData> _matches;
        private List<PlayerData> _playersDataTemp;
        private void Create()
        {
            _matches = new List<MatchData>();
            _playersDataTemp = new List<PlayerData>();
            _playersDataTemp.AddRange(PlayersData);
        }
        public override void PlayRounds()
        {
            int roundCount = CalculateTotalRounds();
            for (int i = 0; i < roundCount; i++)
            {
                Console.Write($" \n ++++++++++++++++++++++Elimination ROUND  {i}++++++++++++++++++++++++ \n");
                PrepareMatches();
                PlayMatches();
            }
        }
        private void PrepareMatches()
        {
            if (_playersDataTemp.Count <= 1) return;
            _matches.Clear();
            for (int i = 0; i < _playersDataTemp.Count - 1; i = 2 + i)
            {
                var matchData = new MatchData(_playersDataTemp[i], _playersDataTemp[i + 1], SurfaceType);
                _matches.Add(matchData);
            }
        }
        private void PlayMatches()
        {
            foreach (var matchData in _matches)
            {
                var loser = MatchController.Play(matchData);
                _playersDataTemp.Remove(loser);
            }
        }
        private int CalculateTotalRounds()
        {
            return (int)Math.Log(_playersDataTemp.Count, 2);
        }

        public EliminationRoundController(SurfaceType surfaceType, List<PlayerData> playersData, IMatchController matchController) : base(surfaceType, playersData, matchController)
        {
            Create();
        }
    }
}