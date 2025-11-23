using System.Collections.Generic;
using TournamentSimulation.Data;
using TournamentSimulation.Round;

namespace TournamentSimulation.Tournament
{
    public class EliminationTournamentController : TournamentControllerBase
    {
        public override void StartTournament()
        {
            IRoundController eliminationRoundController = _roundController;
            eliminationRoundController.PlayRounds();
        }
        public EliminationTournamentController(List<PlayerData> playersData, TournamentData data, IRoundController roundController) : base(playersData, data, roundController)
        {
        }
    }
}