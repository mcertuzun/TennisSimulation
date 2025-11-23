using System.Collections.Generic;
using TournamentSimulation.Data;
using TournamentSimulation.Enums;
using TournamentSimulation.Match;

namespace TournamentSimulation.Round
{
    public abstract class RoundControllerBase : IRoundController
    {
        protected readonly SurfaceType SurfaceType;
        protected readonly List<PlayerData> PlayersData;
        protected readonly IMatchController MatchController;
        protected RoundControllerBase(SurfaceType surfaceType, List<PlayerData> playersData, IMatchController matchController)
        {
            SurfaceType = surfaceType;
            PlayersData = playersData;
            MatchController = matchController;
        }
        public abstract void PlayRounds();
    }

}