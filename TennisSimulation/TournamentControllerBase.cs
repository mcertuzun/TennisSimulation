using System.Collections.Generic;
using TournamentSimulation.Data;
using TournamentSimulation.Match;
using TournamentSimulation.Round;

namespace TournamentSimulation.Tournament
{
    public abstract class TournamentControllerBase
    {
        protected readonly List<PlayerData> _playersData;
        protected readonly TournamentData _data;
        protected readonly IRoundController _roundController;
        protected TournamentControllerBase(List<PlayerData> playersData, TournamentData data, IRoundController roundController)
        {
            _playersData = playersData;
            _data = data;
            _roundController = roundController;
        }
        public abstract void StartTournament();
    }
}