using System.Collections.Generic;
using TournamentSimulation.Data;
using TournamentSimulation.Round;

namespace TournamentSimulation.Tournament
{
    public class LeagueTournamentController : TournamentControllerBase
    {
        public override void StartTournament()
        {
            IRoundController leagueRoundController = _roundController;
            leagueRoundController.PlayRounds();
        }
        public LeagueTournamentController(List<PlayerData> playersData, TournamentData data, IRoundController roundController) : base(playersData, data, roundController)
        {
        }
    }
}